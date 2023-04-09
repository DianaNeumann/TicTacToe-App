using System;

namespace Application.Dto;

public record PlayerDto(int Id, string Name, double EarnedPoints, bool IsPlaying);
