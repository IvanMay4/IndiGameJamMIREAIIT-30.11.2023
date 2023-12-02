using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Saver{

    public static void SaveSettings(){
        StreamWriter writer = new StreamWriter(Settings.filenameSaveSettings);
        writer.WriteLine(Settings.volume + " " + Settings.levelComplexity);
        writer.Close();
    }

    public static void LoadSettings(){
        StreamReader reader = new StreamReader(Settings.filenameSaveSettings);
        string[] valuesSettings = reader.ReadLine().Split();
        Settings.volume = (float)Convert.ToDouble(valuesSettings[0]);
        Settings.levelComplexity = Convert.ToInt32(valuesSettings[1]);
        reader.Close();
    }
}
