using ProspectScouting.Data;
using ProspectScouting.Models.ScoutModels;
using ProspectScouting.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Services
{
    public class ScoutService
    {
        private readonly Guid _userID;

        public ScoutService(Guid userID)
        {
            _userID = userID;
        }

        // CREATE
        public bool CreateScout(ScoutCreate model)
        {
            var entity =
                new Scout()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Scouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // READ

        // GET ALL SCOUTS
        public IEnumerable<ScoutListItem> GetAllScouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Scouts
                        .Select(
                            e =>
                                new ScoutListItem
                                {
                                    ScoutID = e.ScoutID,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName
                                });

                return queary.ToArray();
            }
        }

        // GET BY ID
        public ScoutDetail GetScoutByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scouts
                        .Single(e => e.ScoutID == id);
                return
                        new ScoutDetail
                        {
                            ScoutID = entity.ScoutID,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName
                        };
            }
        }

        // GET BY NAME
        public ScoutDetail GetScoutByName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scouts
                        .Single(e => e.LastName == lastName);
                return
                        new ScoutDetail
                        {
                            ScoutID = entity.ScoutID,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName
                        };
            }
        }

        // UPDATE
        public bool UpdateScout(ScoutEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scouts
                        .Single(e => e.ScoutID == model.ScoutID);

                entity.ScoutID = model.ScoutID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteScout(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Scouts
                        .Single(e => e.ScoutID == id);

                ctx.Scouts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
