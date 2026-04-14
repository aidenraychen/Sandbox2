using static Sandbox.Canvas;

namespace Sandbox
{
    public class CanvasData //defines data for each canvas (canvas num and list of notes)
    {
        public string CanvasUniqueId { get; set; }
        public string CanvasTitle { get; set; }
        public List<NoteData> Notes { get; set; }

        public CanvasData()
        {
            Notes = new List<NoteData>();
            CanvasUniqueId = string.Empty;
            CanvasTitle = string.Empty;
        }

        public static string generateCanvasUniqueId() //form index assigning function
        {
            return $"New Canvas " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

    }

    public class NoteData //defines data for each note
    {
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string BackColor { get; set; }
    }

}
