using System;

namespace Presentation.Models.Movements;

public record MakeMoveModel(Guid GameId, Guid PlayerId, int Position);
