using System;

namespace WinPhone.Interfaces.Models.Shows
{
    using System.Collections.Generic;

    public interface IShowInfo : IBaseShow
    {
        long Id { get; set; }

        int Year { get; set; }

        long? Watching { get; set; }

        long? Voted { get; set; }

        double Rating { get; set; }

        string country { get; set; }

        int? KinopoiskId { get; set; }

        int? TvrageId { get; set; }

        int? ImdbId { get; set; }

        DateTime Started { get; set; }

        List<IEpisode> Episodes { get; set; }
    }
}
