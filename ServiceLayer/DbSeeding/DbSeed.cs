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

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava1.jpg?alt=media&token=b546a8fc-70d7-453a-b3b2-f6bb9bc24e13",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 2,
                Username = "student2",
                FullName = "Đào Thị Bưởi",
                Email = "student2@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava13.jpg?alt=media&token=71817884-6a89-48df-b17f-6026d06d3b68",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 3,
                Username = "student3",
                FullName = "Trần Văn Chình",
                Email = "student3@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava12.jpg?alt=media&token=ef8d1682-3909-415b-9d90-91751291cef2",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 4,
                Username = "student4",
                FullName = "Lí Thị Diệu",
                Email = "student4@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava14.jpg?alt=media&token=09808c4f-4b63-4313-9be9-d04c2d12696f",
                ReportCounter = 0,
                IsBanned = false
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
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava15.jpg?alt=media&token=25fded7b-4825-44d2-9a4c-610d8997daea",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 6,
                Username = "student6",
                FullName = "Lí Chính Phúc",
                Email = "student6@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2F03049ff2-ac7a-46c2-a25d-99ec3dd72da3_6b6f9b3707ab59367512c9066452f086.jpg?alt=media&token=63ac89d8-52cf-4ffd-8e19-a9a82e7ea918",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 7,
                Username = "student7",
                FullName = "Ngô Văn Gia",
                Email = "student7@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava11.png?alt=media&token=d1b4019b-f0f5-46e0-bd4b-f33c4a3115a0",
                ReportCounter = 0,
                IsBanned = false
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
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava16.jpg?alt=media&token=185e4fdc-f8c4-48c6-9000-776633f6d932",
                ReportCounter = 0,
                IsBanned = false
            }
            , new Account
            {
                Id = 9,
                Username = "student9",
                FullName = "Trần Văn Yến",
                Email = "student9@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava17.jpg?alt=media&token=0072919a-68e7-4b46-8475-65bfb433d27d",
                ReportCounter = 0,
                IsBanned = false
            }, new Account
            {
                Id = 10,
                Username = "student10",
                FullName = "Trần Văn Dền",
                Email = "student10@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",

                DateOfBirth = new DateTime(2009,5, 5),
                RoleId = 2,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava18.jpg?alt=media&token=eb7dcb09-965b-4ce7-8cb3-60b72a36f4b7",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 11,
                Username = "student11",
                FullName = "Trần Ba",
                Email = "trankhaiminhkhoi@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava19.jpg?alt=media&token=e2b6d853-8f99-4c49-b772-578039fdc5ac",
                ReportCounter = 0,
                IsBanned = false
            }  ,
            new Account
            {
                Id = 12,
                Username = "student12",
                FullName = "Trần Văn Mạ",
                Email = "student12@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava1.jpg?alt=media&token=b546a8fc-70d7-453a-b3b2-f6bb9bc24e13",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 13,
                Username = "student13",
                FullName = "Trần Văn Mạnh",
                Email = "student12@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava13.jpg?alt=media&token=d5eafa6e-b7e3-4e08-ae77-59825df37794",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 14,
                Username = "student14",
                FullName = "Trần Thi Nhu",
                Email = "student12@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava15.jpg?alt=media&token=8ab16455-e5d9-4342-a24f-db4a20b530f8",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 15,
                Username = "student15",
                FullName = "Trần Khang Huy",
                Email = "student12@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava14.jpg?alt=media&token=b910f818-464a-459f-98a3-fd89c5d9ff5b",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 16,
                Username = "student16",
                FullName = "Giông Ông Tố",
                Email = "student12@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava16.jpg?alt=media&token=0257c11f-5c96-41a9-a949-402a9c3786e6",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 17,
                Username = "student17",
                FullName = "Quang Minh Long",
                Email = "student12@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava17.jpg?alt=media&token=a8a0568b-ff7b-40ff-bf3e-c3970e37ad9b",
                ReportCounter = 0,
                IsBanned = false
            },
            new Account
            {
                Id = 18,
                Username = "duylkse161102",
                FullName = "Liêng Khánh Duy",
                Email = "duylkse161102@gmail.com",
                Password = StringUtils.CustomHash("123456789"),
                Phone = "0123456789",
                DateOfBirth = new DateTime(1975,5, 5),
                RoleId = 1,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fava18.jpg?alt=media&token=91e89058-a5c1-45f4-9430-ef63f0ec0905",
                ReportCounter = 0,
                IsBanned = false
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
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fbetoantap.jpg?alt=media&token=8c8275d3-622b-417a-a41c-3ef59d825caf"
            },
            new Group
            {
                Id = 2,
                Name = "Fullstack toàn tập",
                Description = "Nhóm học tập siêng năng",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Ffullstack.jpg?alt=media&token=18a2bd88-0168-4c9d-abaa-77818a3c64d9"
            } ,
            new Group
            {
                Id = 3,
                Name = "Fullstack",
                Description = "Nhóm học tập siêng năng",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Ffullstactv2.jpg?alt=media&token=c8321b48-0988-477c-ae2a-9e13b5c73e57"
            } ,
            new Group
            {
                Id = 4,
                Name = "Thiết kế web đẹp",
                Description = "Nhóm học tập siêng năng",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2FwebdesignV2.jpg?alt=media&token=f8ab2bcb-f4d6-475d-a6c2-94a063fe1aca"
            },
            new Group
            {
                Id = 5,
                Name = "Design web",
                Description = "Nhóm học tập siêng năng",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fwebdesign.jpg?alt=media&token=4c9e8acf-2a10-4ddd-8ce3-82967fd31a80"
            },
            new Group
            {
                Id = 6,
                Name = "Design mobile",
                Description = "Nhóm học tập siêng năng",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fmobile%20design.jpg?alt=media&token=e6f9ba15-1c9e-41ee-b026-99bdc0df2562"
            },
            new Group
            {
                Id = 7,
                Name = "Mobile Design",
                Description = "Join us to start design mobile",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fmobile%20design.jpg?alt=media&token=e6f9ba15-1c9e-41ee-b026-99bdc0df2562"
            },
            new Group
            {
                Id = 8,
                Name = "Mobile Starter ",
                Description = "Every year more and more people rely on mobile devices to meet their needs. Where websites used to be the gold-standard, people now rely on mobile apps. The technologies used to create these apps are expanding and improving quickly, so it’s an exciting time to start learning Mobile Development!",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fandroid.jpg?alt=media&token=7eaee239-cb80-436f-a336-9da659694fe2"
            },
            new Group
            {
                Id = 9,
                Name = "Mobile Sharing Community",
                Description = "Comunity foor sharing mobile experiences",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fmobile%20design.jpg?alt=media&token=e6f9ba15-1c9e-41ee-b026-99bdc0df2562"
            },
            new Group
            {
                Id = 10,
                Name = "Android Studio Beginner",
                Description = "Android Studio is the official Integrated Development Environment (IDE) for Android app development. Based on the powerful code editor and developer tools from IntelliJ IDEA , Android Studio offers even more features that enhance your productivity when building Android apps",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fandroid.jpg?alt=media&token=7eaee239-cb80-436f-a336-9da659694fe2"
            },
            new Group
            {
                Id = 11,
                Name = "C# Starter",
                Description = "The C# language is the most popular language for the .NET platform, a free, cross-platform, open source development environment. C# programs can run on many different devices, from Internet of Things (IoT) devices to the cloud and everywhere in between. You can write apps for phone, desktop, and laptop computers and servers.",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            },
            new Group
            {
                Id = 12,
                Name = "FU Java OOP",
                Description = "Java is a popular programming language, created in 1995. It is owned by Oracle, and more than 3 billion devices run Java. Welcome to group",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fjava.jpg?alt=media&token=912e4114-0347-4bbe-ba53-51796fbcfc0a"
            },
            new Group
            {
                Id = 13,
                Name = "Operating System Study",
                Description = "An Operating System (OS) is a crucial interface that connects a computer user with the computer's hardware. Falling under the system software category, it handles essential tasks like file management, memory handling, process management, and managing peripheral devices such as disk drives, printers, and networking hardware.",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2FOS.jpg?alt=media&token=5aa509eb-5b12-42b6-92a6-22212f71bb1b"
            },
            new Group
            {
                Id = 14,
                Name = "C Plus Plus ",
                Description = "An Operating System (OS) is a crucial interface that connects a computer user with the computer's hardware. Falling under the system software category, it handles essential tasks like file management, memory handling, process management, and managing peripheral devices such as disk drives, printers, and networking hardware.",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2FC%2B%2B.jpg?alt=media&token=994fa5e4-20a7-41e7-8626-56d3e50b44aa"
            },
            new Group
            {
                Id = 15,
                Name = "SQL Tutorial For Beginner",
                Description = "This SQL tutorial helps you get started with SQL quickly and effectively through many practical examples. If you are a software developer, database administrator, data analyst, or data scientist who wants to use SQL to analyze data, this tutorial is a good start.",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fsql.jpg?alt=media&token=8fab2278-1187-4e62-8752-ec155de94a5f"
            },
            new Group
            {
                Id = 16,
                Name = "SQl Query",
                Description = "SQL stands for Structured Query Language designed to manipulate data in the Relational Database Management Systems (RDBMS).",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fsql.jpg?alt=media&token=8fab2278-1187-4e62-8752-ec155de94a5f"
            },
            new Group
            {
                Id = 17,
                Name = "A I Future",
                Description = "Artificial intelligence (AI) refers to computer systems capable of performing complex tasks that historically only a human could do, such as reasoning, making decisions, or solving problems. ",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fgroupdefault.jpg?alt=media&token=20ff8ea0-a346-4d91-83e5-5b8e792329cb"
            },
            new Group
            {
                Id = 18,
                Name = "Python Python",
                Description = "Welcome! Are you completely new to programming? If not then we presume you will be looking for information about why and how to get started with Python. Fortunately an experienced programmer in any programming language (whatever it may be) can pick up Python very quickly. It's also easy for beginners to use and learn, so jump in!",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Fpython.jpg?alt=media&token=c2b3fbe7-7e18-4b97-aa96-51c82c8354bd"
            },
            new Group
            {
                Id = 19,
                Name = "React",
                Description = "React apps are made out of components. A component is a piece of the UI (user interface) that has its own logic and appearance. A component can be as small as a button, or as large as an entire page.",
                IsBanned = false,
                ImagePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/Images%2Freact.jpg?alt=media&token=27b9137f-87a0-4ddb-9d7d-a32ffa533ba1"
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
                        },
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
                         new GroupMember
                        {
                            //Id = 20,
                            Id = 11,
                            GroupId = 7,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 12,
                            GroupId = 8,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 13 ,
                            GroupId = 9,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 14,
                            GroupId = 10,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 15,
                            GroupId = 11,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 16,
                            GroupId = 12,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 17,
                            GroupId = 13,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 18,
                            GroupId = 14,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 19,
                            GroupId = 15,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 29,
                            GroupId = 16,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },

                          new GroupMember
                        {
                            //Id = 20,
                            Id = 21,
                            GroupId = 17,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },

                          new GroupMember
                        {
                            //Id = 20,
                            Id = 22,
                            GroupId = 18,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },

                          new GroupMember
                        {
                            //Id = 20,
                            Id = 23,
                            GroupId = 19,
                            AccountId = 3,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 24,
                            GroupId = 1,
                            AccountId = 12,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 25,
                            GroupId = 1,
                            AccountId = 13,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 26,
                            GroupId = 1,
                            AccountId = 14,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 27,
                            GroupId = 1,
                            AccountId = 15,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 28,
                            GroupId = 1,
                            AccountId = 16,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 30,
                            GroupId = 1,
                            AccountId = 17,
                            MemberRole = GroupMemberRole.Member,
                            IsActive = true,
                        },
                          new GroupMember
                        {
                            //Id = 20,
                            Id = 23,
                            GroupId = 1,
                            AccountId = 18,
                            MemberRole = GroupMemberRole.Leader,
                            IsActive = true,
                        },
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

            #region Subject other groups 
            new GroupSubject
            {
                Id = 13,
                GroupId = 7,
                SubjectId = (int)SubjectEnum.Flutter
            },
            new GroupSubject
            {
                Id = 14,
                GroupId = 8,
                SubjectId = (int)SubjectEnum.Flutter
            },
            new GroupSubject
            {
                Id = 15,
                GroupId = 9,
                SubjectId = (int)SubjectEnum.Flutter
            },
            new GroupSubject
            {
                Id = 16,
                GroupId = 10,
                SubjectId = (int)SubjectEnum.Flutter
            },
            new GroupSubject
            {
                Id = 17,
                GroupId = 11,
                SubjectId = (int)SubjectEnum.CSharp
            },
            new GroupSubject
            {
                Id = 18,
                GroupId = 12,
                SubjectId = (int)SubjectEnum.Java
            },
            new GroupSubject
            {
                Id = 19,
                GroupId = 13,
                SubjectId = (int)SubjectEnum.BE
            },
            new GroupSubject
            {
                Id = 20,
                GroupId = 14,
                SubjectId = (int)SubjectEnum.CPlusPlus
            },
            new GroupSubject
            {
                Id = 21,
                GroupId = 15,
                SubjectId = (int)SubjectEnum.BE
            },
            new GroupSubject
            {
                Id = 22,
                GroupId = 16,
                SubjectId = (int)SubjectEnum.BE
            },
            new GroupSubject
            {
                Id = 23,
                GroupId = 17,
                SubjectId = (int)SubjectEnum.Python
            },
            new GroupSubject
            {
                Id = 24,
                GroupId = 18,
                SubjectId = (int)SubjectEnum.BE
            },
            new GroupSubject
            {
                Id = 25,
                GroupId = 19,
                SubjectId = (int)SubjectEnum.FE
            },
            new GroupSubject
            {
                Id = 26,
                GroupId = 19,
                SubjectId = (int)SubjectEnum.React
            },
            new GroupSubject
            {
                Id = 27,
                GroupId = 18,
                SubjectId = (int)SubjectEnum.Python
            },
            new GroupSubject
            {
                Id = 28,
                GroupId = 13,
                SubjectId = (int)SubjectEnum.Python
            },
            new GroupSubject
            {
                Id = 29,
                GroupId = 13,
                SubjectId = (int)SubjectEnum.FE
            },
            #endregion

        };
        public static Meeting[] Meetings = new Meeting[]
   {
            #region meeting for group 1
            //Forgoten meeting
            new Meeting
            {
                Id = 1,
                ScheduleId = 1,
                Name=$"Ôn tập kiểm tra C#",
                Content=$"Ôn tập kiểm tra 15p C# {DateTime.Now.AddDays(-3).ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddDays(-3),
                ScheduleEnd = DateTime.Now.AddDays(-3).AddHours(1),
            },
            //Ended schedule meeting
            new Meeting
            {
                Id = 2,
                ScheduleId = 2,
                Name=$"Ôn tập kiểm tra 1 tiết C++",
                Content=$"Ôn tập kiểm tra 1 tiết C++{DateTime.Now.AddMonths(-2).AddDays(-2).ToShortDateString()}",
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
                Name=$"Ôn tập thi C#",
                Content=$"Ôn tập thi C# {DateTime.Now.AddDays(-2).ToShortDateString()}",
                Start = DateTime.Now.AddDays(-2).AddMinutes(30),
                End = DateTime.Now.AddDays(-2).AddHours(2),
                CountMember = 1,
            },
            //Live schedule meeting
            new Meeting
            {
                Id = 4,
                ScheduleId = 4,
                Name=$"Ôn tập kiểm tra 1 tiết C++",
                Content=$"Ôn tập kiểm tra 1 tiết C++{DateTime.Now.ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddMinutes(15),
                ScheduleEnd = DateTime.Now.AddHours(1),
                Start = DateTime.Now.AddMinutes(30),
            },
            //Live Instant meeting
            new Meeting
            {
                Id = 5,
                ScheduleId = 5,
                Name=$"Ôn tập kiểm tra C#",
                Content=$"Ôn tập kiểm tra C# {DateTime.Now.ToShortDateString()}",
                Start = DateTime.Now.AddMinutes(-30),
            },
            //Future Schedule meeting
            new Meeting
            {
                Id = 6,
                ScheduleId = 6,
                Name=$"Ôn tập thi C++",
                Content=$"Ôn tập thi C++ {DateTime.Now.ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddMinutes(-15),
                ScheduleEnd = DateTime.Now.AddHours(1),
            },
            new Meeting
            {
                Id = 7,
                ScheduleId = 7,
                Name=$"Ôn tập thi C#",
                Content=$"Ôn tập thi C# {DateTime.Now.ToShortDateString()}",
                ScheduleStart = DateTime.Now.AddMinutes(15),
                ScheduleEnd = DateTime.Now.AddHours(1),
            },
            new Meeting
            {
                Id = 8,
                ScheduleId = 8,
                Name=$"Ôn tập thi C++",
                Content=$"Ôn tập thi C++ {DateTime.Now.AddDays(1).ToShortDateString()}",
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
                Name=$"Ôn tập kiểm tra 15p C#",
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddDays(-3),
                StartTime = DateTime.Now.AddDays(-3).TimeOfDay,
                EndTime = DateTime.Now.AddDays(-3).AddHours(1).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
                IsActive = true,
            },
            //Ended schedule meeting
            new Schedule
            {
                Id = 2,
                Name=$"Ôn tập kiểm tra 1 tiết C++",
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
                Name=$"Ôn tập thi C#",
                 StartDate = DateTime.Now.AddMonths(-2).AddDays(-2).Date,
                EndDate = DateTime.Now.AddMonths(-2).AddDays(-2).Date,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
            //Live schedule meeting
            new Schedule
            {
                Id = 4,
                Name=$"Ôn tập kiểm tra C++",
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
                Name=$"Ôn tập kiểm tra C#",
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
                Name=$"Ôn tập thi C++",
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
                Name=$"Ôn tập thi C#",
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
                Name=$"Ôn tập thi C++",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                StartTime = DateTime.Now.AddDays(1).AddMinutes(15).TimeOfDay,
                EndTime = DateTime.Now.AddDays(1).AddMinutes(30).TimeOfDay,
                DaysOfWeek = "Chủ Nhật, Thứ Hai, Thứ Ba, Thứ Tư, , Thứ Năm, , Thứ Sáu, Thứ Bảy",
                GroupId = 1,
            },
           #endregion
       };
        public static ScheduleSubject[] ScheduleSubjects = new ScheduleSubject[]
        {
            new ScheduleSubject
            {
                Id =  1,
                ScheduleId = 1,
                SubjectId = (int)SubjectEnum.CSharp
            },
             new ScheduleSubject
            {
                Id=   2,
                ScheduleId= 2,
                SubjectId = (int)SubjectEnum.CPlusPlus
            },
              new ScheduleSubject
            {
                Id=    3,
                ScheduleId=  3,
                SubjectId = (int)SubjectEnum.CSharp
            },
               new ScheduleSubject
            {
                Id=    4,
                ScheduleId=  4,
                SubjectId = (int)SubjectEnum.CPlusPlus
            },
                new ScheduleSubject
            {
                Id= 5,
                ScheduleId=   5,
                SubjectId = (int)SubjectEnum.CSharp
            },
                 new ScheduleSubject
            {
                Id=   6,
                ScheduleId= 6,
                SubjectId = (int)SubjectEnum.CPlusPlus
            },
                  new ScheduleSubject
            {
                Id=    7,
                ScheduleId=  7,
                SubjectId = (int)SubjectEnum.CSharp
            },
                   new ScheduleSubject
            {
                Id =   8,
                ScheduleId = 8,
                SubjectId = (int)SubjectEnum.CPlusPlus
            }
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
              new Report
            {
                Id = 3,
                Detail = "Nội dung không phù hợp",
                SenderId = 1,
                DiscussionId = 2,
                State= RequestStateEnum.Waiting,
            },
               new Report
            {
                Id = 4,
                Detail = "Nội dung không phù hợp",
                SenderId = 1,
                FileId = 2,
                State= RequestStateEnum.Waiting,
            },
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
                FilePath = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/DiscussionFiles%2Fforest.jpg?alt=media&token=58859acc-bfb8-4e56-9a37-558741dd4126",
                IsActive = true,
            } ,
            new Discussion
            {
                Id=2,
                AccountId=2,
                GroupId=1,
                Question="Question 2"  ,
                Content="Within the shrine's shadows, a sense of reverence lingered, as if the spirits of the land themselves sought refuge within its walls",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
                IsActive=true,
            } ,
            new Discussion
            {
                Id=3,
                AccountId=1,
                GroupId=1,
                Question="Question 3"  ,
                Content="Within the shrine's shadows, a sense of reverence lingered, as if the spirits of the land themselves sought refuge within its walls",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
                IsActive=true,
            } ,
            new Discussion
            {
                Id=4,
                AccountId=1,
                GroupId=1,
                Question="Question 4"  ,
                Content="Within the shrine's shadows, a sense of reverence lingered, as if the spirits of the land themselves sought refuge within its walls",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
                IsActive=true,
            } ,
            new Discussion
            {
                Id=5,
                AccountId=1,
                GroupId=1,
                Question="Question 5"  ,
                Content="Within the shrine's shadows, a sense of reverence lingered, as if the spirits of the land themselves sought refuge within its walls",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
                IsActive=true,
            } ,
            new Discussion
            {
                Id=6,
                AccountId=1,
                GroupId=1,
                Question="Question 6"  ,
                Content="Within the shrine's shadows, a sense of reverence lingered, as if the spirits of the land themselves sought refuge within its walls",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
                IsActive=true,
            } ,
            new Discussion
            {
                Id=7,
                AccountId=1,
                GroupId=1,
                Question="Question 7"  ,
                Content="Within the shrine's shadows, a sense of reverence lingered, as if the spirits of the land themselves sought refuge within its walls",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
                IsActive=true,
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
                IsActive = true,
            },
            new AnswerDiscussion
            {
                Id=2,
                AccountId=1,
                DiscussionId=2,
                Content="Bravooo",
                CreateAt = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
                IsActive =true,
            },
        };
        public static DocumentFile[] DocumentFiles = new DocumentFile[]
        {
            new DocumentFile
            {
                Id = 1,
                AccountId = 2,
                GroupId = 1,
                HttpLink = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/DocumentFiles%2F8883342f-6895-4ea8-92d8-4d5c4dfbd0ba_ChangeUI21-3.docx?alt=media&token=62f43e85-c128-4268-91d6-93bc0a943e20",
                Approved = true,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            },
            new DocumentFile
            {
                Id = 2,
                AccountId = 2,
                GroupId = 1,
                HttpLink = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/DocumentFiles%2Ffb858a9d-363c-4bc1-8d5e-61d60c15e32e_Template1.docx?alt=media&token=cfde2b72-22c1-45aa-aa36-82ffa64fcad7",
                Approved = true,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            },
            new DocumentFile
            {
                Id = 3,
                AccountId = 2,
                GroupId = 1,
                HttpLink = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/DocumentFiles%2Ffd8c9e81-7d36-43f7-98b0-e751f63929b8_Template%202.xlsx?alt=media&token=3ad50333-35cd-43d8-9d68-8d67dc85ed77",
                Approved = true,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            },
            new DocumentFile
            {
                Id = 4,
                AccountId = 2,
                GroupId = 1,
                HttpLink = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/DocumentFiles%2Fb460c55e-bc90-4edc-95b5-a028b9c6fe8b_ManyDiagram-System%20Functional%20Overview.jpg?alt=media&token=9c1dfa5f-7bff-4683-986f-4ce68fa79a78",
                Approved = true,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            },
            new DocumentFile
            {
                Id = 5,
                AccountId = 2,
                GroupId = 1,
                HttpLink = "https://firebasestorage.googleapis.com/v0/b/welearn-2024.appspot.com/o/DocumentFiles%2F5e020679-7843-4c1f-909e-7d45372588a0_database.png?alt=media&token=134d6b7c-ad9c-4156-8bcc-25572602bf9d",
                Approved = false,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-2).AddHours(1).AddMinutes(1),
            }
        };
    }
}
