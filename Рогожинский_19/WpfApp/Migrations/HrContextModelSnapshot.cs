﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfApp;

#nullable disable

namespace WpfApp.Migrations
{
    [DbContext(typeof(HrContext))]
    partial class HrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("WpfApp.DepartmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Отдел продаж",
                            Name = "Продажи"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Информационные технологии",
                            Name = "ИТ"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Отдел маркетинга",
                            Name = "Маркетинг"
                        });
                });

            modelBuilder.Entity("WpfApp.EmployeeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "",
                            DepartmentId = 1,
                            FullName = "Елена",
                            IsAvailable = true,
                            Position = "Менеджер"
                        },
                        new
                        {
                            Id = 2,
                            Department = "",
                            DepartmentId = 2,
                            FullName = "Алексей",
                            IsAvailable = true,
                            Position = "Разработчик"
                        },
                        new
                        {
                            Id = 3,
                            Department = "",
                            DepartmentId = 3,
                            FullName = "Мария",
                            IsAvailable = true,
                            Position = "Аналитик"
                        });
                });

            modelBuilder.Entity("WpfApp.EmployeeModel", b =>
                {
                    b.HasOne("WpfApp.DepartmentModel", "DepartmentModel")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentModel");
                });

            modelBuilder.Entity("WpfApp.DepartmentModel", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
