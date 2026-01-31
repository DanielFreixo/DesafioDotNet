using Dominio.Interfaces.InterfaceServicos;
using Dominio.Interfaces.IToDo;
using Dominio.Servico;
using Entidades.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class TodoServiceTest
    {
        //TODO: Colocar o inicialize e mockar as interfaces desejadas

        [TestMethod]
        public void TodoServiceTest_001_List()
        {
            //Config
            Mock<IToDo> _IToDO = new Mock<IToDo>();
            ToDo toDoTest = new ToDo
            {
                ID = 1,
                Titulo = "Título",
                Descricao = "Teste",
                Estado = Entidades.Enums.Enums.StatusToDoEnum.Pendente,
                DataVencimento = System.DateTime.Now.AddDays(3),
            };
            List<ToDo> listaToDo = new List<ToDo> { toDoTest, };
            Task<List<ToDo>> ESPERADO = Task.Run(() => { return listaToDo; });
            _IToDO.Setup(o => o.List()).Returns(ESPERADO);
            ToDoServico toDoServico = new ToDoServico(_IToDO.Object);

            //Act
            var result = toDoServico.Listar();

            //Assert:
            Assert.IsNotNull(result);
            Assert.AreEqual(listaToDo.Count, result.Result.Count);
            CollectionAssert.AreEqual(listaToDo, result.Result);
        }
    }
}
