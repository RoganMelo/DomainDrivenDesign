using DomainDrivenDesign.Infra.Data.Context.Interfaces;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
//using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace DomainDrivenDesign.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory sessionFactory;

        private ITransaction transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(x => x.FromConnectionStringWithKey("ConnectionString")).ShowSql())
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = sessionFactory.OpenSession();
            Session.FlushMode = FlushMode.Commit;
        }

        public void BeginTransaction()
        {
            transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
