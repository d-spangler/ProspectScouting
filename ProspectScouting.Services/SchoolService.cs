using ProspectScouting.Data;
using ProspectScouting.Models.SchoolModels;
using ProspectScouting.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Services
{
    public class SchoolService
    {
        private readonly Guid _userID;

        public SchoolService(Guid userID)
        {
            _userID = userID;
        }

        public SchoolService()
        {
        }

        // CREATE
        public bool CreateSchool(SchoolCreate model)
        {
            var entity =
                new School()
                {
                    SchoolName = model.SchoolName,
                    City = model.City,
                    State = model.State
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // READ

        // GET ALL SCHOOLS
        public IEnumerable<SchoolListItem> GetAllSchools()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Schools
                        .Select(
                            e =>
                                new SchoolListItem
                                {
                                    SchoolID = e.SchoolID,
                                    SchoolName = e.SchoolName,
                                    City = e.City,
                                    State = e.State
                                });

                return queary.ToArray();
            }
        }

        // GET BY ID
        public SchoolDetail GetSchoolByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolID == id);
                return
                        new SchoolDetail
                        {
                            SchoolID = entity.SchoolID,
                            SchoolName = entity.SchoolName,
                            City = entity.City,
                            State = entity.State
                        };
            }
        }

        // GET BY NAME
        public SchoolDetail GetSchoolByName(string schoolName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolName == schoolName);
                return
                        new SchoolDetail
                        {
                            SchoolID = entity.SchoolID,
                            SchoolName = entity.SchoolName,
                            City = entity.City,
                            State = entity.State
                        };
            }
        }

        // GET BY STATE
        public IEnumerable<SchoolDetail> GetSchoolByState(string state)
        {
            Enum.TryParse(state, out ProspectScouting.Data.State type);
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Schools
                        .Where(e => e.State == type).Select(e =>

                        new SchoolDetail
                        {
                            SchoolID = e.SchoolID,
                            SchoolName = e.SchoolName,
                            City = e.City,
                            State = e.State
                        });

                return queary.ToArray();
            }
        }

        // UPDATE
        public bool UpdateSchool(SchoolEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolID == model.SchoolID);

                entity.SchoolID = model.SchoolID;
                entity.SchoolName = model.SchoolName;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteSchool(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolID == id);

                ctx.Schools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
