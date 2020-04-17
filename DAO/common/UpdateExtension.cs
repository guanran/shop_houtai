using DAO.mydata;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAO.common
{
    public static class UpdateExtension
    {
        public static int UpdateEntryByProperty<T>(this MyDataContext _db, T entity, string EntityKey) where T : class
        {
            DbSet<T> dbSet = _db.Set<T>();
            dbSet.Attach(entity);
            MemberInfo[] members = entity.GetType().GetMembers();
            IEnumerable<MemberInfo> properties = members.Where(m => m.MemberType == MemberTypes.Property && m.Name != EntityKey);
            foreach (MemberInfo mInfo in properties)
            {

                object o = entity.GetType().InvokeMember(mInfo.Name, BindingFlags.GetProperty, null, entity, null);
                if (o != null)
                {
                    if (o.GetType().IsPrimitive || o.GetType().IsPublic)
                    {
                        try
                        {
                            DbEntityEntry entry = _db.Entry<T>(entity);
                            entry.Property(mInfo.Name).IsModified = true;
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return _db.SaveChanges();
        }

        public static int UpdateProjectByProperty<T>(this MyDataContext _db, T entity, string EntityKey) where T : class
        {
            DbSet<T> dbSet = _db.Set<T>();
            dbSet.Attach(entity);
            MemberInfo[] members = entity.GetType().GetMembers();
            IEnumerable<MemberInfo> properties = members.Where(m => m.MemberType == MemberTypes.Property && m.Name != EntityKey);
            foreach (MemberInfo mInfo in properties)
            {

                object o = entity.GetType().InvokeMember(mInfo.Name, BindingFlags.GetProperty, null, entity, null);
                if (o != null)
                {
                    if (o.GetType().IsPrimitive || o.GetType().IsPublic)
                    {
                        try
                        {
                            DbEntityEntry entry = _db.Entry<T>(entity);
                            entry.Property(mInfo.Name).IsModified = true;
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    if (mInfo.Name.ToLower() == "opening_time" || mInfo.Name.ToLower() == "checkin_time" || mInfo.Name.ToLower() == "report_effective_hours" || mInfo.Name.ToLower() == "takelook_effective_days" || mInfo.Name.ToLower() == "remarks_kind" || mInfo.Name.ToLower() == "partner_begin_time" || mInfo.Name.ToLower() == "partner_end_time" || mInfo.Name.ToLower() == "takelook_add_num" || mInfo.Name.ToLower() == "dading_add_num")
                    {
                        try
                        {
                            DbEntityEntry entry = _db.Entry<T>(entity);
                            entry.Property(mInfo.Name).IsModified = true;
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return _db.SaveChanges();
        }
    }
}
