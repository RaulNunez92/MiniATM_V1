// Datos precargados de la cuenta (Sección 5 del BRD)
string nombreCliente = "Raynieri Nuñez";
string numeroCuenta = "CTA-1001";
bool cuentaActiva = true;
decimal saldo = 10000m; // Saldo inicial: RD$10,000

bool sesionActiva = true;

// Ciclo interactivo repetitivo (RN-09 y RN-10)
do
{
    Console.WriteLine("\n========================================");
    Console.WriteLine($"   BANCO CENTRAL - MINI ATM V1");
    Console.WriteLine($"   Cliente: {nombreCliente} | Cuenta: {numeroCuenta}");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Consultar saldo");
    Console.WriteLine("2. Depositar dinero");
    Console.WriteLine("3. Retirar dinero");
    Console.WriteLine("4. Salir");
    Console.WriteLine("----------------------------------------");
    Console.Write("Seleccione una opción: ");

    string entradaOpcion = Console.ReadLine() ?? "";

    // RF-12 / RN-11: Validar que la opción sea numérica
    if (!int.TryParse(entradaOpcion, out int opcion))
    {
        Console.WriteLine(">> Error: Debe ingresar una opción numérica válida.");
        continue; // Vuelve al inicio del menú sin cerrar la sesión
    }

    // RF-02: Control de operaciones mediante switch
    switch (opcion)
    {
        case 1: // CU-01: Consultar saldo
            Console.WriteLine($">> Su saldo actual es: RD${saldo:N2}");
            break;

        case 2: // CU-02: Depositar
            // RN-01: Validar cuenta activa
            if (!cuentaActiva)
            {
                Console.WriteLine(">> Error: Cuenta inactiva. No se permiten depósitos.");
                break;
            }

            Console.Write("Ingrese el monto a depositar: ");
            string entradaDeposito = Console.ReadLine() ?? "";

            // RN-11: Validar monto numérico
            if (!decimal.TryParse(entradaDeposito, out decimal montoDeposito))
            {
                Console.WriteLine(">> Error: El monto ingresado no es numérico.");
                break;
            }

            // RN-02: El depósito debe ser mayor a cero
            if (montoDeposito <= 0)
            {
                Console.WriteLine(">> Error: El monto a depositar debe ser mayor que cero.");
                break;
            }

            // RN-05: Depósito válido incrementa saldo
            saldo += montoDeposito;
            Console.WriteLine($">> Depósito exitoso de RD${montoDeposito:N2}. Saldo actual: RD${saldo:N2}");
            break;

        case 3: // CU-03: Retirar
            // RN-01: Validar cuenta activa
            if (!cuentaActiva)
            {
                Console.WriteLine(">> Error: Cuenta inactiva. No se permiten retiros.");
                break;
            }

            Console.Write("Ingrese el monto a retirar: ");
            string entradaRetiro = Console.ReadLine() ?? "";

            // RN-11: Validar monto numérico
            if (!decimal.TryParse(entradaRetiro, out decimal montoRetiro))
            {
                Console.WriteLine(">> Error: El monto ingresado no es numérico.");
                break;
            }

            // RN-03: El retiro debe ser mayor a cero
            if (montoRetiro <= 0)
            {
                Console.WriteLine(">> Error: El monto a retirar debe ser mayor que cero.");
                break;
            }

            // RN-04: El retiro no puede superar el saldo disponible
            if (montoRetiro > saldo)
            {
                Console.WriteLine($">> Error: Fondos insuficientes. Su saldo disponible es: RD${saldo:N2}");
                break;
            }

            // RN-06: Retiro válido disminuye saldo
            saldo -= montoRetiro;
            Console.WriteLine($">> Retiro exitoso de RD${montoRetiro:N2}. Saldo actual: RD${saldo:N2}");
            break;

        case 4: // CU-05 / RN-10: Salir
            Console.WriteLine(">> Sesión finalizada. Gracias por utilizar nuestros servicios.");
            sesionActiva = false;
            break;

        default: // RN-08: Opción no reconocida
            Console.WriteLine(">> Error: Opción no reconocida. Seleccione una opción entre 1 y 4.");
            break;
    }

} while (sesionActiva);
