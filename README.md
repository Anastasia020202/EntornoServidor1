# ParkingApp1 - Sistema de Gestión de Parking

## Descripción del Proyecto

**ParkingApp1** es una aplicación de consola desarrollada en C# (.NET 8) que gestiona un sistema de parking completo. La aplicación permite a los usuarios (clientes y administradores) gestionar plazas de parking, realizar reservas, administrar vehículos y mantener un historial completo de transacciones.

## Características Principales

### Funcionalidades para Clientes
- **Registro e inicio de sesión** con autenticación segura
- **Visualización de plazas disponibles** con precios y disponibilidad
- **Gestión de vehículos** (registro, edición, eliminación)
- **Sistema de reservas** con cálculo automático de precios por horas
- **Historial personal** de reservas realizadas
- **Cancelación de reservas** con devolución automática de stock

### Funcionalidades para Administradores
- **Gestión completa de plazas** (crear, editar, eliminar)
- **Visualización de todas las reservas** del sistema
- **Administración de clientes** (ver, eliminar usuarios)
- **Control de stock** automático de plazas disponibles

### Características Técnicas
- **Arquitectura en capas** con separación clara de responsabilidades
- **Persistencia de datos** en archivos JSON
- **Sistema de autenticación** con roles diferenciados
- **Interfaz de consola** intuitiva y fácil de usar
- **Manejo de errores** robusto con mensajes informativos

## Estructura del Proyecto

```
ParkingApp1/
├── Models/                 # Modelos de datos
│   ├── Usuario.cs         # Clase base abstracta para usuarios
│   ├── Cliente.cs         # Cliente con historial de reservas
│   ├── Admin.cs           # Administrador del sistema
│   ├── Servicio.cs        # Clase base para servicios
│   ├── Plaza.cs           # Plaza de parking
│   ├── Vehiculo.cs        # Vehículo del cliente
│   └── Reserva.cs         # Reserva de parking
├── Repositories/          # Capa de acceso a datos
│   ├── AdminRepository.cs
│   ├── ClienteRepository.cs
│   ├── PlazaRepository.cs
│   ├── VehiculoRepository.cs
│   └── ReservaRepository.cs
├── Services/              # Lógica de negocio
│   └── Sesion.cs          # Gestión de sesiones de usuario
├── ConsoleUI/             # Interfaz de usuario
│   ├── MenuPrincipal.cs   # Menú principal
│   ├── MenuCliente.cs     # Menú específico para clientes
│   └── MenuAdmin.cs       # Menú específico para administradores
├── Configuration/         # Configuración inicial
│   └── Initialization.cs  # Inicialización de datos
├── Utilities/             # Utilidades
│   └── JsonUtility.cs     # Serialización JSON
├── data/                  # Archivos de datos JSON
│   ├── admin.json
│   ├── cliente.json
│   ├── plaza.json
│   ├── vehiculo.json
│   └── reserva.json
├── Dockerfile             # Configuración de contenedor
├── .dockerignore          # Archivos a ignorar en Docker
└── Program.cs             # Punto de entrada de la aplicación
```

## Requisitos del Sistema

- **.NET 8.0** o superior
- **Docker** (para ejecución en contenedor)


## Instalación y Ejecución

### Ejecución Local

1. **Clonar el repositorio**:
   ```bash
   git clone <url-del-repositorio>
   cd ParkingApp1
   ```

2. **Restaurar dependencias**:
   ```bash
   dotnet restore
   ```

3. **Compilar la aplicación**:
   ```bash
   dotnet build
   ```

4. **Ejecutar la aplicación**:
   ```bash
   dotnet run
   ```

### Ejecución con Docker

1. **Construir la imagen**:
   ```bash
   docker build -t parkingapp1 .
   ```

2. **Ejecutar el contenedor**:
   ```bash
   docker run -p 8023:8023 -v $(pwd)/data:/app/data parkingapp1
   ```

3. **Acceder a la aplicación**:
   - La aplicación se ejecutará en el puerto 8023
   - Los datos se persistirán en el volumen `/app/data`

## Uso de la Aplicación

### Primer Uso

1. **Ejecutar la aplicación** - Se inicializarán automáticamente los datos base
2. **Registrarse como cliente** - Opción 3 en el menú principal
3. **Iniciar sesión** - Opción 2 en el menú principal

### Usuario Administrador por Defecto

- **Email**: `admin@parking.com`
- **Contraseña**: `admin123`

### Flujo de Trabajo 

1. **Cliente se registra** en el sistema
2. **Registra su vehículo** con marca, modelo, color y matrícula
3. **Visualiza plazas disponibles** y precios
4. **Realiza una reserva** seleccionando plaza, vehículo y duración
5. **Administrador gestiona** plazas y supervisa reservas

## Modelo de Datos

### Relaciones entre Entidades

- **Usuario** (abstracta) ← **Cliente** y **Admin**
- **Servicio** (abstracta) ← **Plaza**
- **Cliente** → **Vehículo** (relación 1:N)
- **Cliente** → **Reserva** (relación 1:N)
- **Plaza** → **Reserva** (relación 1:N)
- **Vehículo** → **Reserva** (relación 1:N)

### Atributos por Clase

Cada clase cumple con el requisito de tener al menos 6 atributos de tipos variados:
- **String**: nombres, emails, tipos, marcas, modelos, colores
- **int**: IDs, cantidades, horas
- **decimal**: precios, importes
- **boolean**: estado activo
- **DateTime**: fechas de creación, registro, reserva

## Funcionalidades Implementadas

### ✅ Funcionalidades Obligatorias (5/5 puntos)
- [x] Menú principal y secundarios para navegación
- [x] Gestión de alta y selección de usuarios/productos/servicios
- [x] Zona privada de información por usuario
- [x] Zona pública de información
- [x] Modelo de datos con 3+ clases y 6+ atributos cada una
- [x] Funcionalidad de búsqueda
- [x] Containerización con Docker
- [ ] Registro de contenedores

### ✅ Funcionalidades Extra (2/5 puntos)
- [x] Git y metodología Gitflow
- [x] Persistencia de datos en archivos JSON
- [ ] Sistema de logging de errores
- [ ] Variables de entorno en contenedor
- [ ] Interfaz visual con Spectre.Console

## Tecnologías Utilizadas

- **C# .NET 8** - Lenguaje de programación y framework
- **JSON** - Formato de persistencia de datos
- **Docker** - Containerización de la aplicación
- **Git** - Control de versiones con Gitflow
- **POO** - Programación orientada a objetos con herencia y polimorfismo

