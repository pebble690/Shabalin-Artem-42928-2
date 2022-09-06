namespace lab_6
{
    class Class1
    {
        // Название судна
        private string name;
        // Тоннажа
        private int tonnaja;
        // Кол-во экипажа
        private int kolvoEkipaje; 

        // Конструктор класса
        public Class1(string name, int tonnaja, int kolvoEkipaje)
        {
            this.name = name;
            this.tonnaja = tonnaja;
            this.kolvoEkipaje = kolvoEkipaje;
        }

        public override string ToString()
        {
            return "Название судна: " + name + " Тоннажа судна: " + tonnaja + " Кол-во членов экипажа: "+kolvoEkipaje+"\n";
        }

        public int MaxTonnaja
        {
            get { return tonnaja; }
        }
    }
}
