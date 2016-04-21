using DomainDrivenDesign.CrossCutting.Identity.Context;
using DomainDrivenDesign.CrossCutting.Identity.Context.Interfaces;
using DomainDrivenDesign.CrossCutting.Identity.Models;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesign.CrossCutting.Identity.Configuration
{
    public class RoleStore<TRole> : IQueryableRoleStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole
    {
        private bool _disposed;

        /// <summary>
        /// If true then disposing this object will also dispose (close) the session. False means that external code is responsible for disposing the session.
        /// </summary>
        public bool ShouldDisposeSession { get; set; }

        private UnitOfWorkIdentity unitOfWork;

        public RoleStore(IUnitOfWorkIdentity unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            ShouldDisposeSession = true;
            this.unitOfWork = (UnitOfWorkIdentity)unitOfWork;
        }

        private ISession Session { get { return unitOfWork.Session; } }

        public virtual Task<TRole> FindByIdAsync(string roleId)
        {
            ThrowIfDisposed();
            return Task.FromResult(Session.Get<TRole>(roleId));
        }

        public virtual Task<TRole> FindByNameAsync(string roleName)
        {
            ThrowIfDisposed();
            return Task.FromResult(Queryable.FirstOrDefault(Queryable.Where(Session.Query<TRole>(), (u => u.Name.ToUpper() == roleName.ToUpper()))));
        }

        public virtual Task CreateAsync(TRole role)
        {
            ThrowIfDisposed();
            if (role == null)
                throw new ArgumentNullException("role");
            Session.Save(role);
            Session.Flush();
            return Task.FromResult(0);
        }

        public virtual Task DeleteAsync(TRole role)
        {
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            Session.Delete(role);
            Session.Flush();
            return Task.FromResult(0);
        }

        public virtual Task UpdateAsync(TRole role)
        {
            ThrowIfDisposed();
            if (role == null)
                throw new ArgumentNullException("role");
            Session.Update(role);
            Session.Flush();
            return Task.FromResult(0);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed && ShouldDisposeSession)
                Session.Dispose();
            _disposed = true;
            unitOfWork = null;
        }

        public IQueryable<TRole> Roles
        {
            get
            {
                ThrowIfDisposed();
                return Session.Query<TRole>();
            }
        }
    }
}
