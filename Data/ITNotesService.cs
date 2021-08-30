// This is the TNotes Interface
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atastra.Data
{
    // Each item below provides an interface to a method in TNotesServices.cs
    public interface ITNotesService
    {
        Task<bool> TNotesInsert(TNotes tnotes);
        Task<IEnumerable<TNotes>> TNotesGetAll();
        Task<TNotes> TNotesGetOne(int Id);
        Task<bool> TNotesUpdate(TNotes tnotes);
        Task<bool> TNotesDelete(int Id);
    }
}
