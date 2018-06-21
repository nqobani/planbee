using DMNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMNS.DataLayer
{
    public class PlanBeeDataSet
    {
        public User insertuser(string userName, string password, string email)
        {
            using (var db = new PlanBeeDataContext())
            {
                var user = new User
                {
                    username = userName,
                    password = password,
                    email = email
                };

                db.userTable.Add(user);
                db.SaveChanges();

                return user;
            }
        }

        public Project insertProject(string projectName, int userID, string description)
        {
            using (var db = new PlanBeeDataContext())
            {
                var project = new Project
                {
                    name = projectName,
                    userId = userID,
                    createdAt = DateTime.Now,
                    destription = description
                };

                db.projectTable.Add(project);
                db.SaveChanges();

                return project;
            }
        }

        public Meeting insertMeeting(int projectID, string meetingName, string notes, string decisions, string imagePath)
        {
            using (var db = new PlanBeeDataContext())
            {
                var meeting = new Meeting
                {
                    name = meetingName,
                    projectId = projectID,
                    notes = notes,
                    decisions = decisions,
                    createdAt = DateTime.Now,
                    imagePath = imagePath
                };

                db.meetingTable.Add(meeting);
                db.SaveChanges();

                return meeting;
            }
        }

        public Meeting updateMeeting(int id, int projectID = -1, string meetingName = null, string notes = null, string decisions = null, string imagePath = null)
        {
            using (var db = new PlanBeeDataContext())
            {
                var meeting = db.meetingTable.Where(m => m.id == id).FirstOrDefault();

                if (meeting == null)
                    return null;

                if (projectID != -1)
                    meeting.projectId = projectID;

                if (meetingName != null && !meetingName.Equals(null))
                    meeting.name = meetingName;

                if (notes != null && !notes.Equals(null))
                    meeting.notes = notes;

                if (decisions != null && !decisions.Equals(null))
                    meeting.decisions = decisions;

                if (imagePath != null)
                    meeting.imagePath = imagePath;

                db.SaveChanges();

                return meeting;
            }
        }

        public User getUser(string username, string password)
        {
            using (var db = new PlanBeeDataContext())
            {
                var users = db.userTable.Where(u => u.username.Equals(username) && u.password.Equals(password)).FirstOrDefault();

                return users;
            }
        }
        public User getUser(int id)
        {
            using (var db = new PlanBeeDataContext())
            {
                var users = db.userTable.Where(u => u.id == id).FirstOrDefault();

                return users;
            }
        }

        public List<Project> getSharedProjects(int userId)
        {
            using (var db = new PlanBeeDataContext())
            {
                var shareProjects = db.sharedProjectsTable.Where(x => x.sharedTo == userId);

                if (shareProjects == null)
                {
                    return null;
                }
                List<Project> projectList = new List<Project>();
                foreach (var item in shareProjects)
                {
                    using (var dbs = new PlanBeeDataContext())
                    {
                        var project = dbs.projectTable.Where(x => x.id == item.projectId).FirstOrDefault();

                        if (project != null)
                        {
                            projectList.Add(project);
                        }
                    }
                }

                return projectList;
            }
        }

        public List<Meeting> getSharedMeetings(int userId)
        {
            using (var db = new PlanBeeDataContext())
            {
                var shareMeetings = db.sharedMeetingsTable.Where(x => x.sharedTo == userId);

                if (shareMeetings == null)
                {
                    return null;
                }
                List<Meeting> meetingList = new List<Meeting>();
                foreach (var item in shareMeetings)
                {
                    using (var dbs = new PlanBeeDataContext())
                    {
                        var meeting = dbs.meetingTable.Where(x => x.id == item.meetingId).FirstOrDefault();

                        if (meeting != null)
                        {
                            meetingList.Add(meeting);
                        }
                    }
                }

                return meetingList;
            }
        }

        public SharedProjects ShareProject(int sharedBy, int sharedTo, int projectId)
        {
            Project project = getProject(projectId);
            User user = getUser(sharedTo);
            if (project == null || user == null)
            {
                return null;
            }
            using (var db = new PlanBeeDataContext())
            {
                var sharedProject = db.sharedProjectsTable.Where(x => x.sharedTo == sharedTo && x.projectId == projectId).FirstOrDefault();
                if (sharedProject != null)
                    return null;
            }

            using (var db = new PlanBeeDataContext())
            {
                var sharedProject = new SharedProjects
                {
                    sharedBy = sharedBy,
                    sharedTo = sharedTo,
                    projectId = projectId
                };
                db.sharedProjectsTable.Add(sharedProject);
                db.SaveChanges();

                return sharedProject;
            }
        }

        public SharedProjects hasProject(int sharedTo, int projectId)
        {
            using (var db = new PlanBeeDataContext())
            {
                var sharedProject = db.sharedProjectsTable.Where(x => x.sharedTo == sharedTo && x.projectId == projectId).FirstOrDefault();

                return sharedProject;
            }
        }

        public SharedMeetings hasMeeting(int sharedTo, int meetingId)
        {
            using (var db = new PlanBeeDataContext())
            {
                var meetings = db.sharedMeetingsTable.Where(x => x.sharedTo == sharedTo && x.meetingId == meetingId).FirstOrDefault();

                return meetings;
            }
        }

        public SharedMeetings ShareMeeting(int sharedBy, int sharedTo, int meetingId)
        {
            Meeting project = getMeeting(meetingId);
            User user = getUser(sharedTo);
            if (project == null || user == null)
            {
                return null;
            }

            using (var db = new PlanBeeDataContext())
            {
                var sharedMeeting = db.sharedMeetingsTable.Where(x => x.sharedTo == sharedTo && x.meetingId == meetingId).FirstOrDefault();
                if (sharedMeeting != null)
                    return null;
            }
            using (var db = new PlanBeeDataContext())
            {
                var sharedMeeting = new SharedMeetings
                {
                    sharedBy = sharedBy,
                    sharedTo = sharedTo,
                    meetingId = meetingId
                };
                db.sharedMeetingsTable.Add(sharedMeeting);
                db.SaveChanges();

                return sharedMeeting;
            }
        }
        public User getByUsernameOrEmail(string usernameOrEmail)
        {
            using (var db = new PlanBeeDataContext())
            {
                var users = db.userTable.Where(u => u.username.Equals(usernameOrEmail) || u.email.Equals(usernameOrEmail)).FirstOrDefault();

                return users;
            }
        }



        public User resertPasswordEmail(string email, string newPassword)
        {
            using (var db = new PlanBeeDataContext())
            {
                var user = db.userTable.Where(u => u.email.Equals(email)).FirstOrDefault();

                if (user == null)
                    return user;

                user.password = newPassword;
                db.SaveChanges();

                return user;
            }
        }
        public User resertPasswordUsername(string username, string newPassword)
        {
            using (var db = new PlanBeeDataContext())
            {
                var user = db.userTable.Where(u => u.username.Equals(username)).FirstOrDefault();

                if (user == null)
                    return user;

                user.password = newPassword;
                db.SaveChanges();

                return user;
            }
        }

        public Project getProject(int id)
        {
            using (var db = new PlanBeeDataContext())
            {
                var projects = db.projectTable.Where(p => p.id == id).FirstOrDefault();

                return projects;
            }
        }

        public List<Project> getUserProjects(int userId)
        {
            using (var db = new PlanBeeDataContext())
            {
                var projects = db.projectTable.Where(p => p.userId == userId);

                return projects.ToList();
            }
        }

        public Meeting getMeeting(int id)
        {
            using (var db = new PlanBeeDataContext())
            {
                var meetings = db.meetingTable.Where(m => m.id == id).FirstOrDefault();

                return meetings;
            }
        }


        public List<Meeting> getProjectMeatings(int projectId)
        {
            using (var db = new PlanBeeDataContext())
            {
                var meetings = db.meetingTable.Where(m => m.projectId == projectId);

                return meetings.ToList();
            }
        }

        public List<User> getAllUsers()
        {
            using (var db = new PlanBeeDataContext())
            {
                var users = db.userTable.Where(u => u.id != -1);

                return users.ToList();
            }
        }

        public List<Project> getAllProjects()
        {
            using (var db = new PlanBeeDataContext())
            {
                var projects = db.projectTable.Where(p => p.id != -1);

                return projects.ToList();
            }
        }

        public List<Meeting> getAllMeetings()
        {
            using (var db = new PlanBeeDataContext())
            {
                var meetings = db.meetingTable.Where(m => m.id != -1);

                return meetings.ToList();
            }
        }

        public bool deleleProject(int projectId)
        {
            bool delete = false;
            using (var db = new PlanBeeDataContext())
            {
                var project = db.projectTable.Where(m => m.id == projectId).SingleOrDefault();

                if (project != null) {
                    db.projectTable.Remove(project);
                    db.SaveChanges();
                    delete = true;
                }

                using (var dbs = new PlanBeeDataContext())
                {
                    var meetings = dbs.meetingTable.Where(v => v.projectId == projectId);
                    if(meetings != null) {
                        dbs.meetingTable.RemoveRange(meetings);
                        dbs.SaveChanges();
                        delete = true;
                    }
                }

                using (var dbs = new PlanBeeDataContext())
                {
                    var sharedprojects = dbs.sharedProjectsTable.Where(v => v.projectId == projectId);
                    if (sharedprojects != null)
                    {
                        dbs.sharedProjectsTable.RemoveRange(sharedprojects);
                        dbs.SaveChanges();
                        delete = true;
                    }
                }
                return delete;
            }
        }
        public bool deleteMeeting(int meetingId)
        {
            bool delete = false;
            using (var db = new PlanBeeDataContext())
            {
                var meetings = db.meetingTable.Where(v => v.id == meetingId);
                if (meetings != null)
                {
                    db.meetingTable.RemoveRange(meetings);
                    db.SaveChanges();
                    delete = true;
                }
            }
            return delete;
        }
    }
}