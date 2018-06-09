using DMNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMNS.DataLayer
{
    public class PlanBeeDataSet
    {
        public User insertuser(string userName,string password,string email)
        {
            using (var db = new PlanBeeDataContext()) {
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
        
        public Project insertProject(string projectName,int userID)
        {
            using (var db = new PlanBeeDataContext())
            {
                var project = new Project
                {
                    name = projectName,
                    userId = userID,
                    createdAt = DateTime.Now
                };

                db.projectTable.Add(project);
                db.SaveChanges();

                return project;
            }
        }
        
        public Meeting insertMeeting(int projectID,string meetingName, string notes, string decisions)
        {
            using (var db = new PlanBeeDataContext())
            {
                var meeting = new Meeting
                {
                    name = meetingName,
                    projectId = projectID,
                    notes = notes,
                    decisions = decisions,
                    createdAt = DateTime.Now
                };

                db.meetingTable.Add(meeting);
                db.SaveChanges();

                return meeting;
            }
        }

        public User getUser(string username, string password)
        {
            using (var db = new PlanBeeDataContext())
            {
                var users = db.userTable.Where(u => u.username.Equals(username)&& u.password.Equals(password)).FirstOrDefault();

                return users;
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

    }
}