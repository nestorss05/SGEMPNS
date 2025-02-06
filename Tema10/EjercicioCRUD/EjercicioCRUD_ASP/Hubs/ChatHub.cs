using EjercicioCRUD_ENT;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace EjercicioCRUD_ASP.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(clsMensajeUsuario mensajeUsuario)
        {
            await Clients.Group(mensajeUsuario.grupo).SendAsync("ReceiveMessage", mensajeUsuario);
        }

        public async Task JoinRoom(clsMensajeUsuario mensajeUsuario)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, mensajeUsuario.grupo);
        }

        public async Task LeaveRoom(clsMensajeUsuario mensajeUsuario)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, mensajeUsuario.grupo);
        }
    }
}
