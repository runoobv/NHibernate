using ActivitiesApi.Common.Https;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ISession session = NHDemoHelper.GetCurrentSession();
            ITransaction tx = session.BeginTransaction();

            #region 插入

            //Cat cat = new Cat();
            //cat.Id = "2";
            //cat.Name = "Test2";
            //cat.Sex = 'M';
            //cat.Weight = 7.3F;

            //session.Save(cat);

            #endregion 插入

            var query = session.CreateSQLQuery("select * from Cat").List().OfType<Cat>().ToList<Cat>();
            //query.
            //var sds = query.List();
            //query.SetCharacter("sex", 'F');
            //foreach (Cat item in query.List<Cat>())
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Id);
            //}
            tx.Commit();
            NHDemoHelper.CloseSession();
            Console.ReadKey();
        }
    }
}