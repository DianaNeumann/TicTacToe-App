using System;

namespace Application.Dto;

public record PlayerDto(Guid Id, string Name, bool IsPlaying);
