// Install
sc create RESP.Extension.Server binPath= <exe path> DisplayName= RESP Extension Server
sc description RESP.Extension.Server RESP.app Extension Server base on .NET 6.0

// Uninstall
sc delete RESP.Extension.Server