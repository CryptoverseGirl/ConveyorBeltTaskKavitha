public enum  BoxType
   {
      PerfectBox,
      DamagedBox
   }

   [System.Serializable]
   public struct Box
   {
      public string name;
      public BoxType boxType;
   }

