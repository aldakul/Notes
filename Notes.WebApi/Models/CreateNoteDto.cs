using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.WebApi.Models;

public class CreateNoteDto
    : IMapWith<CreateNoteCommand>
{
    private string? Title { get; set; }
    private string? Details { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
            .ForMember(command => command.Title,
                expression => expression.MapFrom(dto => dto.Title))
            .ForMember(command => command.Details,
                expression => expression.MapFrom(dto => dto.Details));
    }
}