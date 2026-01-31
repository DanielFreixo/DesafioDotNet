using Dominio.Interfaces.IGenericas;
using Infra.Conifguracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class GenericoRepositorio<T> : IGenerica<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuiler;

        public GenericoRepositorio()
        {
            _OptionsBuiler = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T objeto)
        {
            using (var data = new ContextBase(_OptionsBuiler))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objecto)
        {
            using (var data = new ContextBase(_OptionsBuiler))
            {
                data.Set<T>().Remove(objecto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetByID(int id)
        {
            using (var data = new ContextBase(_OptionsBuiler))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_OptionsBuiler))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T objeto)
        {
            using (var data = new ContextBase(_OptionsBuiler))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }

        #region IDisposable
        private bool disposedValue;
        System.Runtime.InteropServices.SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    handle.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GenericoRepositorio()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
