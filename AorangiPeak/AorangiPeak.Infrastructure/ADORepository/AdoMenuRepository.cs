using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AorangiPeak.Infrastructure.ADORepository
{
    public class AdoMenuRepository : IMenuRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        #region constructor
        public AdoMenuRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }
        #endregion

        public IQueryable<Menu> FindAll()
        {
            List<Menu> menus = new List<Menu>();
            string sql = "SELECT * FROM [AP_Menus] WHERE Status<>2";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                Menu menu = new Menu(new Guid(sdr["RowID"].ToString()),
                                                sdr["Name"].ToString(),
                                                sdr["Img1"].ToString(),
                                                sdr["Img2"].ToString(),
                                                sdr["Intro"].ToString(),
                                                sdr["Content"].ToString(),
                                                (MenuStatus)Convert.ToInt32(sdr["Status"]));

                menus.Add(menu);
            }
            sdr.Close();
            return menus.AsQueryable();
        }

        public IQueryable<Menu> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public Menu FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public Menu FindBy(Guid key)
        {
            Menu menu = null;

            string sql = "SELECT TOP 1  Name, Img1, Img2, Intro, Content, Status "
                           + "FROM [AP_Menus] "
                           + "WHERE RowID = @id";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", key) };
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql, sp);
            while (sdr.Read())
            {
                menu = new Menu(key,
                                                sdr["Name"].ToString(),
                                                sdr["Img1"].ToString(),
                                                sdr["Img2"].ToString(),
                                                sdr["Intro"].ToString(),
                                                sdr["Content"].ToString(),
                                                (MenuStatus)Convert.ToInt32(sdr["Status"]));
            }
            sdr.Close();

            return menu;
        }

        public void Add(Menu menu)
        {
            _context.RegisterNew(menu, this);
        }

        public void Save(Menu menu)
        {
            _context.RegisterAmended(menu, this);
        }

        public void Remove(Menu menu)
        {
            _context.RegisterRemoved(menu, this);
        }

        public void PersistCreationOf(IAggregateRoot root)
        {
            Menu menu = root as Menu;
            string sql = "INSERT INTO [AP_Menus] (Name, Img1, Img2, Intro, Content, Status, RowID) "
                            +"VALUES (@name,@img1,@img2,@intro,@content,@status,@rid)";
            SqlParameter[] sp = new SqlParameter[]
                                                  {
                                                      new SqlParameter("@name", menu.Menuname),
                                                      new SqlParameter("@img1", menu.Firstimg),
                                                      new SqlParameter("@img2", menu.Secondimg),
                                                      new SqlParameter("@intro", menu.Introduction),
                                                      new SqlParameter("@content", menu.Content),
                                                      new SqlParameter("@status", menu.Status),
                                                      new SqlParameter("@rid", menu.Id)
                                                  };
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistUpdateOf(IAggregateRoot root)
        {
            Menu menu = root as Menu;
            string sql = "UPDATE [AP_Menus]  SET Name = @name, Img1 = @img1, "
                             +"Img2 = @img2, Intro = @intro, Content = @content, Status = @status "
                             +"WHERE RowID = @rid";
            SqlParameter[] sp = new SqlParameter[]
                                                  {
                                                      new SqlParameter("@name", menu.Menuname),
                                                      new SqlParameter("@img1", menu.Firstimg),
                                                      new SqlParameter("@img2", menu.Secondimg),
                                                      new SqlParameter("@intro", menu.Introduction),
                                                      new SqlParameter("@content", menu.Content),
                                                      new SqlParameter("@status", menu.Status),
                                                      new SqlParameter("@rid", menu.Id)
                                                  };
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistDeletionOf(IAggregateRoot root)
        {
            Menu menu = root as Menu;
            string sql = "UPDATE [AP_Menus] SET Status = 2 WHERE RowID = @rid";
            SqlParameter[] sp = new SqlParameter[] {
                   new SqlParameter("@rid", menu.Id)
            };
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }
    }
}
