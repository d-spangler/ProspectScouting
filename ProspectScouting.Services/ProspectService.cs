using ProspectScouting.Data;
using ProspectScouting.Models.ProspectModels;
using ProspectScouting.Models.SchoolModels;
using ProspectScouting.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Services
{
    public class ProspectService
    {
        private readonly Guid _userID;

        public ProspectService(Guid userID)
        {
            _userID = userID;
        }

        // CREATE
        public bool CreateProspect(ProspectCreate model)
        {
            var entity =
                new Prospect()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    School = model.School,
                    SchoolID = model.SchoolID,
                    Report = model.Report,
                    Grade = model.Grade,
                    BigBoard = model.BigBoard
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Prospects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // READ

        // GET ALL PROSPECTS
        public IEnumerable<ProspectListItem> GetAllProspects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Prospects
                        .Select(
                            e =>
                                new ProspectListItem
                                {
                                    ProspectID = e.ProspectID,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Position = e.Position,
                                    School = e.School,
                                    Report = e.Report,
                                    Grade = e.Grade,
                                    BigBoard = e.BigBoard
                                });

                return queary.ToArray();
            }
        }
        
        // GET BY ID
        public ProspectDetail GetProspectByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.ProspectID == id);
                return
                        new ProspectDetail
                        {
                            ProspectID = entity.ProspectID,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Position = entity.Position,
                            School = entity.School,
                            SchoolID = entity.SchoolID,
                            Report = entity.Report,
                            Grade = entity.Grade,
                            BigBoard = entity.BigBoard
                        };
            }
        }

        // GET BY NAME
        public ProspectDetail GetProspectByName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.LastName == lastName);
                return
                        new ProspectDetail
                        {
                            ProspectID = entity.ProspectID,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Position = entity.Position,
                            School = entity.School,
                            Report = entity.Report,
                            Grade = entity.Grade,
                            BigBoard = entity.BigBoard
                        };
            }
        }

        // GET BY POSITION
        public IEnumerable<ProspectDetail> GetProspectByPosition(string position)
        {
            Enum.TryParse(position, out ProspectScouting.Data.Position type);
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Prospects
                        .Where(e => e.Position == type).Select(e =>

                        new ProspectDetail
                        {
                            ProspectID = e.ProspectID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Position = e.Position,
                            School = e.School,
                            Report = e.Report,
                            Grade = e.Grade,
                            BigBoard = e.BigBoard
                        });

                return queary.ToArray();
            }
        }

        // GET BY SCHOOL
        public ProspectDetail GetProspectsBySchool(string school)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.School.SchoolName == school);
                return
                        new ProspectDetail
                        {
                            ProspectID = entity.ProspectID,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Position = entity.Position,
                            School = entity.School,
                            Report = entity.Report,
                            Grade = entity.Grade,
                            BigBoard = entity.BigBoard
                        };
            }
        }

        // GET BY BIG BOARD
        public IEnumerable<ProspectListItem> GetProspectByBigBoard()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Prospects
                        .Where(e => e.BigBoard == true).Select(e =>

                        new ProspectListItem
                        {
                            ProspectID = e.ProspectID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Position = e.Position,
                            School = e.School,
                            Report = e.Report,
                            Grade = e.Grade,
                            BigBoard = e.BigBoard
                        });

                return queary.ToArray();
            }
        }

        // UPDATE
        public bool UpdateProspect(ProspectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.ProspectID == model.ProspectID);

                entity.ProspectID = model.ProspectID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Position = model.Position;
                //entity.School = model.School;
                entity.SchoolID = model.SchoolID;
                entity.Report = model.Report;
                entity.Grade = model.Grade;
                entity.BigBoard = model.BigBoard;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteProspect(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.ProspectID == id);

                ctx.Prospects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
