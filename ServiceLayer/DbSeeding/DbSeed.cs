﻿using DataLayer.DbObject;
using DataLayer.Enums;
using ServiceLayer.Utils;
using System.Net.NetworkInformation;

namespace ServiceLayer.DbSeeding
{
    public static class DbSeed
    {
        public static Role[] Roles = new Role[] {
            new Role
            {
                Id = 1,
                Name = "Parent"
            },
            new Role
            {
                Id = 2,
                Name = "Student"
            }};
        public static Account[] Accounts = new Account[] {
            new Account
            {
                Id = 1,
                Username = "student1",
                FullName = "Trần Khải Minh Khôi",
                Email = "trankhaiminhkhoi10a3@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 2,
                Username = "student2",
                FullName = "Đào Thị Bưởi",
                Email = "student2@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 3,
                Username = "student3",
                FullName = "Trần Văn Chình",
                Email = "student3@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 4,
                Username = "student4",
                FullName = "Lí Thị Diệu",
                Email = "student4@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 5,
                Username = "student5",
                FullName = "Trần Văn Em",
                Email = "student5@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 6,
                Username = "student6",
                FullName = "Lí Chính Phúc",
                Email = "student6@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 7,
                Username = "student7",
                FullName = "Ngô Văn Gia",
                Email = "student7@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 8,
                Username = "student8",
                FullName = "Trần Văn Hơn",
                Email = "student8@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            }
            , new Account
            {
                Id = 9,
                Username = "student9",
                FullName = "Trần Văn Yến",
                Email = "student9@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            }, new Account
            {
                Id = 10,
                Username = "student10",
                FullName = "Trần Văn Dền",
                Email = "student10@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                Career="THCS Minh Đức",
                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2
            },
            new Account
            {
                Id = 11,
                Username = "parent1",
                FullName = "Trần Ba",
                Email = "trankhaiminhkhoi@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1
            }  ,
            new Account
            {
                Id = 12,
                Username = "parent2",
                FullName = "Trần Văn Mạ",
                Email = "parent2@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1
            }
        };
        public static Subject[] Subjects = new Subject[]
        {
            new Subject
            {
                Id = 1,
                Name = "Back end"
            },
            new Subject
            {
                Id = 2,
                Name = "Front end"
            },
            new Subject
            {
                Id = 3,
                Name = "Mobile"
            },
            new Subject
            {
                Id = 4,
                Name = "C"
            },
            new Subject
            {
                Id = 5,
                Name = "C++"
            },
            new Subject
            {
                Id = 6,
                Name = "C#"
            },
            new Subject
            {
                Id = 7,
                Name = "Java"
            },
            new Subject
            {
                Id = 8,
                Name = "Python"
            } ,
            new Subject
            {
                Id = 9,
                Name = "Node Js"
            }   ,
             new Subject
            {
                Id = 10,
                Name = "Js"
            },
              new Subject
            {
                Id = 11,
                Name = "React"
            },
               new Subject
            {
                Id = 12,
                Name = "Flutter"
            }
        };
        public static Group[] Groups = new Group[]
        {
            new Group
            {
                Id = 1,
                Name = "BE toàn tập",
                Description = "Nhóm học tập siêng năng",
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            },
            new Group
            {
                Id = 2,
                Name = "Thánh gánh tem",
                Description = "Nhóm học tập siêng năng",
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            } ,
            new Group
            {
                Id = 3,
                Name = "Fullstack",
                Description = "Nhóm học tập siêng năng",
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            } ,
            new Group
            {
                Id = 4,
                Name = "Thiết kế web đẹp",
                Description = "Nhóm học tập siêng năng",
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            },
            new Group
            {
                Id = 5,
                Name = "Design web",
                Description = "Nhóm học tập siêng năng",
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            },
            new Group
            {
                Id = 6,
                Name = "Design mobile",
                Description = "Nhóm học tập siêng năng",
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            },
        };
        public static GroupMember[] GroupMembers = new GroupMember[]
        {
                        #region Member Group 1
                        new GroupMember
                        {
                            Id = 1,
                            GroupId = 1,
                            AccountId = 1,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                        new GroupMember
                        {
                            Id = 2,
                            GroupId = 1,
                            AccountId = 2,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                            //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        },
                        //Fix later
                        //new GroupMember
                        //{
                        //    Id = 3,
                        //    GroupId = 1,
                        //    AccountId = 3,
                        //    State = GroupMemberState.Inviting,
                        //    //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        //},
                        //new GroupMember
                        //{
                        //    Id = 4,
                        //    GroupId = 1,
                        //    AccountId = 4,
                        //    State = GroupMemberState.Requesting,
                        //    //RequestMessage = "Nhóm của bạn rất hay. Bạn cho mình vô nha"
                        //},
                        new GroupMember
                        {
                            //Id = 5,
                            Id = 3,
                            GroupId = 1,
                            AccountId = 5,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                            //RequestMessage = "Nhóm của bạn rất hay. Bạn cho mình vô nha"
                        },
                        #endregion
                        #region Member group 2
                        new GroupMember
                        {
                            //Id = 6,
                            Id = 4,
                            GroupId = 2,
                            AccountId = 1,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                        new GroupMember
                        {
                            //Id = 7,
                            Id = 5,
                            GroupId = 2,
                            AccountId = 2,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                            ////InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        },
                        //new GroupMember
                        //{
                        //    Id = 8,
                        //    GroupId = 2,
                        //    AccountId = 3,
                        //    State = GroupMemberState.Requesting,
                        //    //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        //},
                        //new GroupMember
                        //{
                        //    Id = 9,
                        //    GroupId = 2,
                        //    AccountId = 4,
                        //    State = GroupMemberState.Inviting,
                        //    //RequestMessage = "Nhóm của bạn rất hay. Bạn cho mình vô nha"
                        //},
                        #endregion   
                        #region Member group 3
                        new GroupMember
                        {
                            //Id = 10,
                            Id = 6,
                            GroupId = 3,
                            AccountId = 2,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                        new GroupMember
                        {
                            //Id = 11,
                            Id = 7,
                            GroupId = 3,
                            AccountId = 1,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                            //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        },
                        //new GroupMember
                        //{
                        //    Id = 12,
                        //    GroupId = 3,
                        //    AccountId = 3,
                        //    State = GroupMemberState.Inviting,
                        //    //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        //},
                        //new GroupMember
                        //{
                        //    Id = 13,
                        //    GroupId = 3,
                        //    AccountId = 4,
                        //    State = GroupMemberState.Requesting,
                        //    //RequestMessage = "Nhóm của bạn rất hay. Bạn cho mình vô nha"
                        //},
                        #endregion
                        #region member group 4
                        new GroupMember
                        {
                            //Id = 14,
                            Id = 8,
                            GroupId = 4,
                            AccountId = 2,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                        // new GroupMember
                        //{
                        //    Id = 15,
                        //    GroupId = 4,
                        //    AccountId = 3,
                        //    State = GroupMemberState.Inviting,
                        //    //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        //},
                        //new GroupMember
                        //{
                        //    Id = 16,
                        //    GroupId = 4,
                        //    AccountId = 4,
                        //    State = GroupMemberState.Requesting,
                        //    //RequestMessage = "Nhóm của bạn rất hay. Bạn cho mình vô nha"
                        //},
                        #endregion
                        #region member group 5
                        new GroupMember
                        {
                            //Id = 17,
                            Id = 9,
                            GroupId = 5,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                        // new GroupMember
                        //{
                        //    Id = 18,
                        //    GroupId = 5,
                        //    AccountId = 3,
                        //    State = GroupMemberState.Inviting,
                        //    //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        //},
                        //new GroupMember
                        //{
                        //    Id = 19,
                        //    GroupId = 5,
                        //    AccountId = 3,
                        //    State = GroupMemberState.Requesting,
                        //    //RequestMessage = "Nhóm của bạn rất hay. Bạn cho mình vô nha"
                        //},
                        #endregion
                        #region member group 6
                        new GroupMember
                        {
                            //Id = 20,
                            Id = 10,
                            GroupId = 6,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        }
                        // new GroupMember
                        //{
                        //    Id = 21,
                        //    GroupId = 6,
                        //    AccountId = 2,
                        //    State = GroupMemberState.Inviting,
                        //    //InviteMessage = "Nhóm của mình rất hay. Bạn vô nha"
                        //},
                        //new GroupMember
                        //{
                        //    Id = 22,
                        //    GroupId = 6,
                        //    AccountId = 1,
                        //    State = GroupMemberState.Requesting,
                        //    //RequestMessage = "Nhóm của bạn rất hay. Bạn cho mình vô nha"
                        //},
                        #endregion
        };
        public static GroupSubject[] GroupSubjects = new GroupSubject[]
        {
            #region Subject Group 1
            new GroupSubject
            {
                Id = 1,
                GroupId = 1,
                SubjectId = (int)SubjectEnum.BE
            },
            new GroupSubject
            {
                Id = 2,
                GroupId = 1,
                SubjectId = (int)SubjectEnum.CPlusPlus
            },
            new GroupSubject
            {
                Id = 3,
                GroupId = 1,
                SubjectId = (int)SubjectEnum.CSharp
            },
            #endregion
            #region Subject group 2
            new GroupSubject
            {
                Id = 4,
                GroupId = 2,
                SubjectId = (int)SubjectEnum.BE
            },
            new GroupSubject
            {
                Id = 5,
                GroupId = 2,
                SubjectId = (int)SubjectEnum.FE
            },
            new GroupSubject
            {
                Id = 6,
                GroupId = 2,
                SubjectId = (int)SubjectEnum.MO
            } ,
            #endregion
            #region Subject group 3
            new GroupSubject
            {
                Id = 7,
                GroupId = 3,
                SubjectId = (int)SubjectEnum.BE
            },
            new GroupSubject
            {
                Id = 8,
                GroupId = 3,
                SubjectId = (int)SubjectEnum.FE
            },
            #endregion
            #region Subject group 4
            new GroupSubject
            {
                Id = 9,
                GroupId = 4,
                SubjectId = (int)SubjectEnum.FE
            },
            new GroupSubject
            {
                Id = 10,
                GroupId = 5,
                SubjectId = (int)SubjectEnum.React
            },
            #endregion
            #region Subject group 5
            new GroupSubject
            {
                Id = 11,
                GroupId = 5,
                SubjectId = (int)SubjectEnum.React
            },
            #endregion
            #region Subject group 6
            new GroupSubject
            {
                Id = 12,
                GroupId = 6,
                SubjectId = (int)SubjectEnum.MO
            },
            #endregion
            new GroupSubject
            {
                Id = 13,
                GroupId = 6,
                SubjectId = (int)SubjectEnum.Flutter
            },
        };
        public static Meeting[] Meetings = new Meeting[]
   {
            #region meeting for group 1
            //Forgoten meeting
            new Meeting
            {
                Id = 1,
                ScheduleId = 1,
                Name=$"Ôn tập kiểm tra 15p",
                Content=$"Ôn tập kiểm tra 15p {DateTime.Now.AddDays(-3).ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddDays(-3),
                ScheduleEnd = DateTime.Now.AddDays(-3).AddHours(1),
            },
            //Ended schedule meeting
            new Meeting
            {
                Id = 2,
                ScheduleId = 2,
                Name=$"Ôn tập kiểm tra 1 tiết",
                Content=$"Ôn tập kiểm tra 1 tiết {DateTime.Now.AddMonths(-2).AddDays(-2).ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddMonths(-2).AddDays(-2).AddMinutes(15),
                ScheduleEnd = DateTime.Now.AddMonths(-2).AddDays(-2).AddHours(1),
                Start = DateTime.Now.AddMonths(-2).AddDays(-2).AddMinutes(30),
                End = DateTime.Now.AddMonths(-2).AddDays(-2).AddHours(2),
                CountMember = 1,
            },
            //Ended instant meeting
            new Meeting
            {
                Id = 3,
                ScheduleId = 3,
                Name=$"Ôn tập thi toán",
                Content=$"Ôn tập thi toán {DateTime.Now.AddDays(-2).ToShortDateString()}",
                Start = DateTime.Now.AddDays(-2).AddMinutes(30),
                End = DateTime.Now.AddDays(-2).AddHours(2),
                CountMember = 1,
            },
            //Live schedule meeting
            new Meeting
            {
                Id = 4,
                ScheduleId = 4,
                Name=$"Ôn tập kiểm tra lí",
                Content=$"Ôn tập kiểm tra lí {DateTime.Now.ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddMinutes(15),
                ScheduleEnd = DateTime.Now.AddHours(1),
                Start = DateTime.Now.AddMinutes(30),
            },
            //Live Instant meeting
            new Meeting
            {
                Id = 5,
                ScheduleId = 5,
                Name=$"Ôn tập kiểm tra",
                Content=$"Ôn tập kiểm tra {DateTime.Now.ToShortDateString()}",
                Start = DateTime.Now.AddMinutes(-30),
            },
            //Future Schedule meeting
            new Meeting
            {
                Id = 6,
                ScheduleId = 6,
                Name=$"Ôn tập thi toán",
                Content=$"Ôn tập thi toán {DateTime.Now.ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddMinutes(-15),
                ScheduleEnd = DateTime.Now.AddHours(1),
            },
            new Meeting
            {
                Id = 7,
                ScheduleId = 7,
                Name=$"Ôn tập thi lí",
                Content=$"Ôn tập thi lí {DateTime.Now.ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddMinutes(15),
                ScheduleEnd = DateTime.Now.AddHours(1),
            },
            new Meeting
            {
                Id = 8,
                ScheduleId = 8,
                Name=$"Ôn tập thi Toán",
                Content=$"Ôn tập thi Toán {DateTime.Now.AddDays(1).ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddDays(1).AddMinutes(15),
                ScheduleEnd = DateTime.Now.AddDays(1).AddHours(1),
            },
       #endregion
   };
        public static Schedule[] Schedules = new Schedule[]
       {
            #region meeting for group 1
            //Forgoten meeting
            new Schedule
            {
                Id = 1,
                Name=$"Ôn tập kiểm tra 15p",
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddDays(-3),
                StartTime = DateTime.Now.AddDays(-3).TimeOfDay,
                EndTime = DateTime.Now.AddDays(-3).AddHours(1).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            //Ended schedule meeting
            new Schedule
            {
                Id = 2,
                Name=$"Ôn tập kiểm tra 1 tiết",
                StartDate = DateTime.Now.AddMonths(-2).AddDays(-2).Date,
                EndDate = DateTime.Now.AddMonths(-2).AddDays(-2).Date,
                StartTime = DateTime.Now.AddMonths(-2).AddDays(-2).AddMinutes(30).TimeOfDay,
                EndTime = DateTime.Now.AddMonths(-2).AddDays(-2).AddHours(2).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            //Ended instant meeting
            new Schedule
            {
                Id = 3,
                Name=$"Ôn tập thi toán",
                 StartDate = DateTime.Now.AddMonths(-2).AddDays(-2).Date,
                EndDate = DateTime.Now.AddMonths(-2).AddDays(-2).Date,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            //Live schedule meeting
            new Schedule
            {
                Id = 4,
                Name=$"Ôn tập kiểm tra lí",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                StartTime = DateTime.Now.AddMinutes(15).TimeOfDay,
                EndTime = DateTime.Now.AddHours(1).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            //Live Instant meeting
            new Schedule
            {
                Id = 5,
                Name=$"Ôn tập kiểm tra",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                StartTime = DateTime.Now.AddMinutes(-30).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            //Future Schedule meeting
            new Schedule
            {
                Id = 6,
                Name=$"Ôn tập thi toán",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                StartTime = DateTime.Now.AddMinutes(-15).TimeOfDay,
                EndTime = DateTime.Now.AddMinutes(30).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            new Schedule
            {
                Id = 7,
                Name=$"Ôn tập thi lí",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                StartTime = DateTime.Now.AddMinutes(15).TimeOfDay,
                EndTime = DateTime.Now.AddMinutes(30).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            new Schedule
            {
                Id = 8,
                Name=$"Ôn tập thi Toán",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                StartTime = DateTime.Now.AddDays(1).AddMinutes(15).TimeOfDay,
                EndTime = DateTime.Now.AddDays(1).AddMinutes(30).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
           #endregion
       };
        public static Invite[] Invites = new Invite[]
        {
            #region Group 1
            new Invite {
                Id = 1,
                GroupId= 1,
                AccountId=2,
                State = RequestStateEnum.Approved
            },
            new Invite
            {
                Id = 2,
                GroupId = 1,
                AccountId = 3,
                State = RequestStateEnum.Waiting,
            },
            #endregion

            #region Group 2
                new Invite
            {
                Id = 3,
                GroupId = 2,
                AccountId = 2,
                State = RequestStateEnum.Approved,
            },
            new Invite
            {
                Id = 4,
                GroupId = 2,
                AccountId = 3,
                State = RequestStateEnum.Waiting,
            },
            #endregion 

            #region Group 3
            new Invite
            {
                Id = 5,
                GroupId = 3,
                AccountId = 1,
                State = RequestStateEnum.Approved,
            },
            new Invite
            {
                Id = 6,
                GroupId = 3,
                AccountId = 3,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 4
            new Invite
            {
                Id = 7,
                GroupId = 4,
                AccountId = 3,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 5
            new Invite
            {
                Id = 8,
                GroupId = 5,
                AccountId = 3,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 6
            new Invite
            {
                Id = 9,
                GroupId = 6,
                AccountId = 2,
                State = RequestStateEnum.Waiting,
            },
            new Invite
            {
                Id = 10,
                GroupId = 6,
                AccountId = 1,
                State = RequestStateEnum.Waiting,
            },
            #endregion

        };
        public static Request[] Requests = new Request[]
        {
                        
            #region Group 1
            new Request
            {
                Id = 1,
                GroupId = 1,
                AccountId = 4,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 2
            new Request
            {
                Id = 2,
                GroupId = 2,
                AccountId = 3,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 3
                new Request
            {
                Id = 3,
                GroupId = 3,
                AccountId = 4,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 4
            new Request
            {
                Id = 4,
                GroupId = 4,
                AccountId = 4,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 5
            new Request
            {
                Id = 5,
                GroupId = 5,
                AccountId = 3,
                State = RequestStateEnum.Waiting,
            },
            #endregion
                        
            #region Group 6
            new Request
            {
                Id = 6,
                GroupId = 6,
                AccountId = 1,
                State = RequestStateEnum.Waiting,
            },
            #endregion
        };
        public static Connection[] Connections = new Connection[]
        {
            #region Meeting 2
            new Connection
            {
                SinganlrId= "Id1",
                AccountId = 1,
                MeetingId = 2,
                Start = DateTime.Now.AddDays(-2).AddMinutes(30),
                End = DateTime.Now.AddDays(-2).AddMinutes(45),
                UserName = "student1",
            },
            new Connection
            {
                SinganlrId= "Id2",
                AccountId = 1,
                MeetingId = 2,
                Start = DateTime.Now.AddDays(-2).AddHours(1),
                End = DateTime.Now.AddDays(-2).AddHours(2),
                UserName = "student1",
            },
             new Connection
            {
                SinganlrId= "Id3",
                AccountId = 1,
                MeetingId = 3,
                Start = DateTime.Now.AddMonths(-2).AddDays(-2).AddHours(1),
                End = DateTime.Now.AddMonths(-2).AddDays(-2).AddHours(2),
                UserName = "student1",
            },

            #endregion
        };
        public static Review[] Reviews = new Review[]
        {
            new Review
            {
                Id = 1,
                MeetingId=2,
                RevieweeId=1,
            } ,
             new Review
            {
                Id = 2,
                MeetingId=2,
                RevieweeId=1,
            }
        };
        public static ReviewDetail[] ReviewDetails = new ReviewDetail[]
        {
            new ReviewDetail
            {
                Id=1,
                ReviewId=1,
                ReviewerId=1,
                Result=ReviewResultEnum.VeryGood,
                Comment="Bạn thuộc bài rất kĩ"
            }    ,
            new ReviewDetail
            {
                Id=2,
                ReviewId=2,
                ReviewerId=1,
                Result=ReviewResultEnum.Good,
                Comment="Bạn thuộc bài khá"
            }
        };
        public static Chat[] Chats = new Chat[]
        {
            new Chat
            {
                Id=1,
                Content="Xin lỗi mình vô trễ",
                MeetingId=2,
                AccountId=1,
                Time = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            } ,
            new Chat
            {
                Id=2,
                Content="Mình mới vào",
                MeetingId=2,
                AccountId=1,
                Time = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1).AddSeconds(10),
            }

        };
        public static Report[] Reports = new Report[]
        {
            new Report
            {
                Id = 1,
                Detail = "Tên không phù hợp",
                SenderId = 1,
                AccountId = 2,
                State= RequestStateEnum.Waiting,
            },
             new Report
            {
                Id = 2,
                Detail = "Tên không phù hợp",
                SenderId = 1,
                GroupId = 2,
                State= RequestStateEnum.Waiting,
            },
            //  new Report
            //{
            //    Id = 3, 
            //    Detail = "Nội dung không phù hợp",
            //    SenderId = 1,
            //    DiscussionId = 2,
            //    State= RequestStateEnum.Waiting,
            //},
            //   new Report
            //{
            //    Id = 4,
            //    Detail = "Nội dung không phù hợp",
            //    SenderId = 1,
            //    FileId = 2,
            //    State= RequestStateEnum.Waiting,
            //},
        };
        public static Discussion[] Discussions = new Discussion[]
        {
            new Discussion
            {
                Id=1,
                AccountId=1,
                GroupId=1,
                Question="Question 1"  ,              
                Content="In the heart of the forest, where ancient trees whispered secrets to the wind, there stood a forgotten shrine,",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            } ,
            new Discussion
            {
                Id=2,
                AccountId=2,
                GroupId=1,
                Question="Question 2"  ,
                Content="Within the shrine's shadows, a sense of reverence lingered, as if the spirits of the land themselves sought refuge within its walls",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            } ,
        };
        public static AnswerDiscussion[] AnswerDiscussions = new AnswerDiscussion[]
        {
            new AnswerDiscussion
            {
                Id=1,
                AccountId=2,
                DiscussionId=1,
                Content="Nice job",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            },
            new AnswerDiscussion
            {
                Id=2,
                AccountId=1,
                DiscussionId=2,
                Content="Bravooo",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            },
        };
    }
}
