﻿using DMNS.DataLayer;
using DMNS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DMNS.LogicLayer
{
    public class LogicBlaBlaBla
    {
        private PlanBeeDataSet planBeeDataSet = new PlanBeeDataSet();

        public User addUser(string username, string email, string password, string confirmPassword)
        {
            //Do your validation before this part
            return planBeeDataSet.insertuser(username, password, email);
        }
        public Project addProject(string projectName, int userID, string description)
        {
            //Do your validation...
            return planBeeDataSet.insertProject(projectName, userID, description);
        }

        public Meeting insertMeeting(int projectID, string meetingName, string notes, string decisions, string imagePath)
        {
            //Do your validation ....

            return planBeeDataSet.insertMeeting(projectID, meetingName, notes, decisions, imagePath);
        }

        public Meeting updateMeeting(int id, int projectID = -1, string meetingName = null, string notes = null, string decisions = null)
        {
            return planBeeDataSet.updateMeeting(id, projectID, meetingName, notes, decisions);
        }

        public User getUser(string username, string password)
        {
            return planBeeDataSet.getUser(username, password);
        }

        public User getUserByUsernameOrPassword(string usernameOrPassword)
        {
            return planBeeDataSet.getByUsernameOrEmail(usernameOrPassword);
        }

        public User resertPasswordUsername(string username, string password)
        {
            return planBeeDataSet.resertPasswordUsername(username, password);
        }

        public User resertPasswordEmail(string email, string password)
        {
            return planBeeDataSet.resertPasswordEmail(email, password);
        }

        public SharedProjects ShareProject(int sharedBy, int sharedTo, int projectId)
        {
            return planBeeDataSet.ShareProject(sharedBy, sharedTo, projectId);
        }

        public SharedMeetings ShareMeetings(int sharedBy, int sharedTo, int meetingId)
        {
            return planBeeDataSet.ShareMeeting(sharedBy, sharedTo, meetingId);
        }

        public List<Meeting> getSharedMeetings(int userId)
        {
            return planBeeDataSet.getSharedMeetings(userId);
        }

        public List<Project> getSharedProjects(int userId)
        {
            return planBeeDataSet.getSharedProjects(userId);
        }


        public SharedProjects hasProject(int sharedTo, int projectId)
        {
            return planBeeDataSet.hasProject(sharedTo, projectId);
        }

        public SharedMeetings hasMeeting(int sharedTo, int meetingId)
        {
            return planBeeDataSet.hasMeeting(sharedTo, meetingId);
        }


        public Project getProject(int id)
        {
            return planBeeDataSet.getProject(id);
        }

        public Meeting getMeeting(int id)
        {
            return planBeeDataSet.getMeeting(id);
        }
        public List<Project> getUserProjects(int userId)
        {
            return planBeeDataSet.getUserProjects(userId);
        }

        public List<Meeting> getProjectMeetings(int projectId)
        {
            return planBeeDataSet.getProjectMeatings(projectId);
        }

        public List<User> getAllUsers()
        {
            return planBeeDataSet.getAllUsers();
        }

        public List<Project> getAllProjects()
        {
            return planBeeDataSet.getAllProjects();
        }

        public List<Meeting> getAllMeetings()
        {
            return planBeeDataSet.getAllMeetings();
        }
        public bool deleteMeeting(int meetingId)
        {
            return planBeeDataSet.deleteMeeting(meetingId);
        }
        public bool deleteProject(int projectId)
        {
            return planBeeDataSet.deleleProject(projectId);
        }
    }
}