using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebApi.Models;

public class UpdateNoteDto:IMapWith<UpdateNoteCommand>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
            .ForMember(command => command.Id,
                expression => expression.MapFrom(dto => dto.Id))
            .ForMember(command => command.Title,
                expression => expression.MapFrom(dto => dto.Title))
            .ForMember(command => command.Details,
                expression => expression.MapFrom(dto => dto.Details)); 
    }
}