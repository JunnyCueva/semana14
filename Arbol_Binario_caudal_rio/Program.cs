using System;

class Nodo {
    public int Edad;
    public Nodo Izquierda, Derecha;

    public Nodo(int edad) {
        Edad = edad;
        Izquierda = Derecha = null;
    }
}

class ArbolBinario {
    private Nodo raiz;

    public void Insertar(int edad) {
        raiz = InsertarRec(raiz, edad);
    }

    private Nodo InsertarRec(Nodo nodo, int edad) {
        if (nodo == null) return new Nodo(edad);
        if (edad < nodo.Edad)
            nodo.Izquierda = InsertarRec(nodo.Izquierda, edad);
        else
            nodo.Derecha = InsertarRec(nodo.Derecha, edad);
        return nodo;
    }

    public void PreOrden() {
        PreOrdenRec(raiz);
        Console.WriteLine();
    }

    private void PreOrdenRec(Nodo nodo) {
        if (nodo != null) {
            Console.Write(nodo.Edad + " ");
            PreOrdenRec(nodo.Izquierda);
            PreOrdenRec(nodo.Derecha);
        }
    }

    public void InOrden() {
        InOrdenRec(raiz);
        Console.WriteLine();
    }

    private void InOrdenRec(Nodo nodo) {
        if (nodo != null) {
            InOrdenRec(nodo.Izquierda);
            Console.Write(nodo.Edad + " ");
            InOrdenRec(nodo.Derecha);
        }
    }

    public void PostOrden() {
        PostOrdenRec(raiz);
        Console.WriteLine();
    }

    private void PostOrdenRec(Nodo nodo) {
        if (nodo != null) {
            PostOrdenRec(nodo.Izquierda);
            PostOrdenRec(nodo.Derecha);
            Console.Write(nodo.Edad + " ");
        }
    }

    public bool Buscar(int edad) {
        return BuscarRec(raiz, edad);
    }

    private bool BuscarRec(Nodo nodo, int edad) {
        if (nodo == null) return false;
        if (nodo.Edad == edad) return true;
        return edad < nodo.Edad ? BuscarRec(nodo.Izquierda, edad) : BuscarRec(nodo.Derecha, edad);
    }
}

class Program {
    static void Main() {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, valor;

        do {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1. Insertar edad");
            Console.WriteLine("2. Mostrar PreOrden");
            Console.WriteLine("3. Mostrar InOrden");
            Console.WriteLine("4. Mostrar PostOrden");
            Console.WriteLine("5. Buscar una edad");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion) {
                case 1:
                    Console.Write("Ingrese la edad: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    break;
                case 2:
                    Console.Write("PreOrden: ");
                    arbol.PreOrden();
                    break;
                case 3:
                    Console.Write("InOrden: ");
                    arbol.InOrden();
                    break;
                case 4:
                    Console.Write("PostOrden: ");
                    arbol.PostOrden();
                    break;
                case 5:
                    Console.Write("Ingrese la edad a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Edad encontrada." : "Edad NO encontrada.");
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion invalida. Intenta de nuevo.");
                    break;
            }
        } while (opcion != 6);
    }
}
