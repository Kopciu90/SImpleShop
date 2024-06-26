﻿using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleShop.Infrastructure
{
    public static class DatabaseSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                if (!context.Roles.Any())
                {
                    var roles = new List<Role>
                    {
                        new Role { Name = "Admin" },
                        new Role { Name = "User" }
                    };
                    context.Roles.AddRange(roles);
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    var products = new List<Product>
                    {
                        new Product { Name = "Product1", Price = 10.99M },
                        new Product { Name = "Product2", Price = 15.99M },
                        new Product { Name = "Product3", Price = 20.99M }
                    };
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    var adminRole = context.Roles.First(r => r.Name == "Admin");
                    var userRole = context.Roles.First(r => r.Name == "User");

                    var users = new List<User>
                    {
                        new User
                        {
                            Username = "admin",
                            Password = "admin123",
                            Orders = new List<Order>
                            {
                                new Order
                                {
                                    OrderDate = DateTime.Now,
                                    OrderDetails = new List<OrderDetail>
                                    {
                                        new OrderDetail
                                        {
                                            Product = context.Products.First(p => p.Name == "Product1"),
                                            Quantity = 1,
                                            UnitPrice = 10.99M
                                        }
                                    }
                                }
                            },
                            UserRoles = new List<UserRole>
                            {
                                new UserRole
                                {
                                    Role = adminRole
                                }
                            }
                        },
                        new User
                        {
                            Username = "user",
                            Password = "user123",
                            Orders = new List<Order>
                            {
                                new Order
                                {
                                    OrderDate = DateTime.Now,
                                    OrderDetails = new List<OrderDetail>
                                    {
                                        new OrderDetail
                                        {
                                            Product = context.Products.First(p => p.Name == "Product2"),
                                            Quantity = 2,
                                            UnitPrice = 15.99M
                                        }
                                    }
                                }
                            },
                            UserRoles = new List<UserRole>
                            {
                                new UserRole
                                {
                                    Role = userRole
                                }
                            }
                        }
                    };

                    context.Users.AddRange(users);
                    context.SaveChanges();
                }
            }
        }
    }
}
