using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sandbox
{
    public static class CanvasManager
    {
       
        public static List<CanvasData> AllCanvas { get; set; } = new List<CanvasData>();

        public static void EnsureLoaded()
        {
            if (AllCanvas != null) return;
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "SandboxNotes.json"
            );
            if(!File.Exists(path))
            {
                AllCanvas = new List<CanvasData>();
                File.WriteAllText(path, "[]");
                return;
            }
            AllCanvas = JsonSerializer.Deserialize<List<CanvasData>>(File.ReadAllText(path)) ?? new List<CanvasData>();
        }
    }
}
