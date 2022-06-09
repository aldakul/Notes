using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Tests.Common;
using Xunit;

namespace Notes.Tests.Notes.Commands;

public class CreateNoteCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateNoteCommandHandler_Success()
    {
        //Arrange - Подготовка данных
        var handler = new CreateNoteCommandHandler(Context);
        var noteTitle = "note title";
        var noteDetails = "note details";
        
        //Act - Выполнение логики
        var noteId = await handler.Handle(
            new CreateNoteCommand
            {
                Title = noteTitle,
                Details = noteDetails,
                UserId = NotesContextFactory.UserAId
            },
            CancellationToken.None);

        //Assert - Проверка результатов
        Assert.NotNull(
            await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == noteId && note.Title == noteTitle && 
                note.Details == noteDetails));
    }
}