using DataLayer.DbObject;
using ServiceLayer.Utils;

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
                Schhool="THCS Minh Đức",
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
                Schhool="THCS Minh Đức",
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
                Schhool="THCS Minh Đức",
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
                Schhool="THCS Minh Đức",
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
                Schhool="THCS Minh Đức",
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
                Schhool="THCS Minh Đức",
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
                Schhool="THCS Minh Đức",
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
                Schhool="THCS Minh Đức",
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

    }
}
