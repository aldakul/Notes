using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common;

public class NotesContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
    
    public static Guid NoteIdForDelete = Guid.NewGuid();
    public static Guid NoteIdForUpdate = Guid.NewGuid();

    public static NotesDbContext Create()
    {
        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new NotesDbContext(options);
        context.Database.EnsureCreated();
        context.Notes.AddRange(
            new Note
            {
                CreateDate = DateTime.Today,
                Details = "Details1",
                UpdateDate = null,
                Id = Guid.Parse("C1F3C8A1-07F4-48CC-B55B-6B95683C1C35"),
                Title = "Title1",
                UserId = UserAId
            },
            new Note
            {
                CreateDate = DateTime.Today,
                Details = "Details2",
                UpdateDate = null,
                Id = Guid.Parse("CA534F0D-617F-4CDC-8752-4F9ADA269A24"),
                Title = "Title2",
                UserId = UserBId
            },
            new Note
            {
                CreateDate = DateTime.Today,
                Details = "Details3",
                UpdateDate = null,
                Id = NoteIdForDelete,
                Title = "Title3",
                UserId = UserAId
            },
            new Note
            {
                CreateDate = DateTime.Today,
                Details = "Details4",
                UpdateDate = null,
                Id = NoteIdForUpdate,
                Title = "Title4",
                UserId = UserBId
            });
        context.SaveChanges();
        return context;
    }

    public static void Destroy(NotesDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}