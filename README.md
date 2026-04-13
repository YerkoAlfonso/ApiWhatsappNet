# WhatsaapNet API

## Descripción

WhatsaapNet es una API backend desarrollada en ASP.NET Core para integrar aplicaciones con la WhatsApp Cloud API. Permite recibir webhooks, enrutar mensajes entrantes y enviar mensajes salientes desde aplicaciones externas.

## Tecnologías

- .NET 7 / .NET 8
- ASP.NET Core (Web API)
- C#

## Estructura principal

- Solución: [WhatsaapNet.sln](WhatsaapNet.sln)
- Proyecto API: [WhatsaapNet.Api](WhatsaapNet.Api/)
- Punto de entrada: [WhatsaapNet.Api/Program.cs](WhatsaapNet.Api/Program.cs)
- Controladores: [WhatsaapNet.Api/Controllers](WhatsaapNet.Api/Controllers) — incluye `WhatsappController`
- Modelos: [WhatsaapNet.Api/Models/WhatsAppCloud/WhatsAppCloudModel.cs](WhatsaapNet.Api/Models/WhatsAppCloud/WhatsAppCloudModel.cs)
- Servicios: [WhatsaapNet.Api/Services/WhatsAppCloud/SendMessage/](WhatsaapNet.Api/Services/WhatsAppCloud/SendMessage/)
- Utilidades: [WhatsaapNet.Api/Util/Util.cs](WhatsaapNet.Api/Util/Util.cs) y [WhatsaapNet.Api/Util/IUtil.cs](WhatsaapNet.Api/Util/IUtil.cs)
- Configuración y publicación: [WhatsaapNet.Api/appsettings.json](WhatsaapNet.Api/appsettings.json), [WhatsaapNet.Api/Properties/PublishProfiles](WhatsaapNet.Api/Properties/PublishProfiles)

## Características

- Recepción y validación de webhooks de WhatsApp.
- Endpoints para enviar mensajes mediante WhatsApp Cloud API.
- Modelos que representan los payloads de WhatsApp Cloud.
- Servicios desacoplados para la lógica de envío y construcción de mensajes.
- Utilitarios compartidos para tareas comunes (config, serialización, logging ligero).

## Casos de uso

- Enviar mensajes programáticos desde una aplicación o backend.
- Procesar mensajes entrantes y ejecutar lógica de negocio.
- Integrar notificaciones y respuestas automáticas.

## Cómo ejecutar (local)

1. Restaurar y compilar la solución:

```powershell
dotnet restore WhatsaapNet.sln
dotnet build WhatsaapNet.sln
```

2. Ejecutar el proyecto API:

```powershell
cd WhatsaapNet.Api
dotnet run
```

## Despliegue

Configurar las credenciales y variables necesarias en `appsettings.json` o en variables de entorno antes de publicar. Se incluyen perfiles de publicación en `WhatsaapNet.Api/Properties/PublishProfiles`.

## Siguientes mejoras recomendadas

- Añadir verificación y autenticación de webhooks.
- Persistir el historial de mensajes en una base de datos.
- Implementar colas y reintentos para envíos masivos.

---

Si quieres, puedo también crear un commit y empujar (`git push`) el archivo al repositorio remoto. ¿Lo hago?
