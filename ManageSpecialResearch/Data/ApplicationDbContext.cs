﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ManageSpecialResearch.Models;
using Microsoft.AspNetCore.Identity;

namespace ManageSpecialResearch.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Добавляю таблицы
        public DbSet<ManageSpecialResearch.Models.Request> Request { get; set; }
        public DbSet<ManageSpecialResearch.Models.Stage> Stage { get; set; }

        //Заполняю значения по умолчанию
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Этапы заявки по умолчанию
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 1,
                StageName = "Заявка принята"
            });
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 2,
                StageName = "Испытания проведены"
            });
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 3,
                StageName = "Предписание выдано"
            });
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 4,
                StageName = "Заявка закрыта"
            });



            //Права доступа(роли) по умолчанию
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a1c31d1c-5cc3-4aee-89eb-ecdf62d5a8a1",//Сгенерирован на сайте https://www.guidgenerator.com/online-guid-generator.aspx
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ea5f39f9-3bcd-42bf-b7cb-a3b2dfbf317d",//Сгенерирован на сайте https://www.guidgenerator.com/online-guid-generator.aspx
                Name = "receiver",
                NormalizedName = "RECEIVER"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "c03b6828-8288-41fb-b295-3f410aa4b3c0",//Сгенерирован на сайте https://www.guidgenerator.com/online-guid-generator.aspx
                Name = "tester",
                NormalizedName = "TESTER"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "f51eee01-1b9d-490b-b630-ae5997d4c65b",//Сгенерирован на сайте https://www.guidgenerator.com/online-guid-generator.aspx
                Name = "controller",
                NormalizedName = "CONTROLLER"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "78ff2dc9-f218-4c8e-921c-54977ac86bf4",//Сгенерирован на сайте https://www.guidgenerator.com/online-guid-generator.aspx
                Name = "manager",
                NormalizedName = "MANAGER"
            });

            //Юзер
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "b9724707-432b-4ea1-a6ee-4ff3e61988c8",//Сгенерирован на сайте https://www.guidgenerator.com/online-guid-generator.aspx
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "mt@mail.com",
                NormalizedEmail = "mt@mail.com".ToUpper(),
                EmailConfirmed = true,//чтобы было
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            });

            //Связать юзера и роль
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "a1c31d1c-5cc3-4aee-89eb-ecdf62d5a8a1",
                UserId = "b9724707-432b-4ea1-a6ee-4ff3e61988c8"
            });


                //builder.Entity<Request>().HasData(new Request
                //{
                //    Id = new Guid("12000000-0000-0000-0000-000000000000"),
                //    Number = "002",
                //    CreateDate = DateTime.Parse("11.11.20"),
                //    Stage = 1
                //});
                //builder.Entity<Request>().HasData(new Request
                //{
                //    Id = new Guid("13000000-0000-0000-0000-000000000000"),
                //    Number = "003",
                //    CreateDate = DateTime.Parse("11.11.20"),
                //    Stage = 2
                //});
        }
    }
}
