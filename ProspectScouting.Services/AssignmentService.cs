using ProspectScouting.Data;
using ProspectScouting.Models.AssignmentModels;
using ProspectScouting.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Services
{
    public class AssignmentService
    {
        private readonly Guid _userID;

        public AssignmentService(Guid userID)
        {
            _userID = userID;
        }

        // CREATE
        public bool CreateAssignment(AssignmentCreate model)
        {
            var entity =
                new Assignment()
                {
                    AssignmentRequest = model.AssignmentRequest,
                    School = model.School,
                    SchoolID = model.SchoolID,
                    Scout = model.Scout,
                    ScoutID = model.ScoutID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // READ

        // GET ALL ASSIGNMENTS
        public IEnumerable<AssignmentListItem> GetAllAssignments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queary =
                    ctx
                        .Assignments
                        .Select(
                            e =>
                                new AssignmentListItem
                                {
                                    AssignmentID = e.AssignmentID,
                                    AssignmentRequest = e.AssignmentRequest,
                                    School = e.School,
                                    Scout = e.Scout,
                                    Completed = e.Completed,
                                });

                return queary.ToArray();
            }
        }

        // GET BY ID
        public AssignmentDetail GetAssignmentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentID == id);
                return
                        new AssignmentDetail
                        {
                            AssignmentID = entity.AssignmentID,
                            AssignmentRequest = entity.AssignmentRequest,
                            School = entity.School,
                            Scout = entity.Scout,
                            Completed = entity.Completed
                        };
            }
        }

        //// GET BY SCHOOL
        //public AssignmentDetail GetAssignmentBySchool(string schoolName)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Assignments
        //                .Single(e => e.School.SchoolName == schoolName);
        //        return
        //                new AssignmentDetail
        //                {
        //                    AssignmentID = entity.AssignmentID,
        //                    AssignmentRequest = entity.AssignmentRequest,
        //                    School = entity.School,
        //                    Scout = entity.Scout,
        //                    Completed = entity.Completed
        //                };
        //    }
        //}

        //// GET BY SCOUT
        //public AssignmentDetail GetAssignmentByScout(string scoutLastName)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Assignments
        //                .Single(e => e.Scout.LastName == scoutLastName);
        //        return
        //                new AssignmentDetail
        //                {
        //                    AssignmentID = entity.AssignmentID,
        //                    AssignmentRequest = entity.AssignmentRequest,
        //                    School = entity.School,
        //                    Scout = entity.Scout,
        //                    Completed = entity.Completed
        //                };
        //    }
        //}

        // GET ASSIGNMENTS IN PROGRESS
        public AssignmentDetail GetActiveAssignments(bool completed)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.Completed == false);
                return
                        new AssignmentDetail
                        {
                            AssignmentID = entity.AssignmentID,
                            AssignmentRequest = entity.AssignmentRequest,
                            School = entity.School,
                            Scout = entity.Scout,
                            Completed = entity.Completed
                        };
            }
        }

        // GET COMPLETED ASSIGNMENTS
        public AssignmentDetail GetCompletedAssignments(bool completed)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.Completed == true);
                return
                        new AssignmentDetail
                        {
                            AssignmentID = entity.AssignmentID,
                            AssignmentRequest = entity.AssignmentRequest,
                            School = entity.School,
                            Scout = entity.Scout,
                            Completed = entity.Completed
                        };
            }
        }

        // UPDATE
        public bool UpdateAssignment(AssignmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentID == model.AssignmentID);

                entity.AssignmentID = model.AssignmentID;
                entity.AssignmentRequest = model.AssignmentRequest;
                entity.School = model.School;
                entity.Scout = model.Scout;
                entity.Completed = model.Completed;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteAssignment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentID == id);

                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
