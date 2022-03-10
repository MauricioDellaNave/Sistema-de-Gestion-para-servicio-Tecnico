/****
Este script SQL fue creado por el cuadro de diálogo Configurar sincronización
de datos. Este script contiene instrucciones que crean las columnas
de seguimiento de cambios, la tabla de elementos eliminados y los
desencadenadores en la base de datos de servidor. Estos objetos de base
de datos son necesarios para que los Servicios de sincronización sincronicen
correctamente los datos entre las bases de datos del cliente y del servidor.
Para obtener más información, vea el tema ‘Cómo configurar un servidor de bases de datos para la sincronización’ en la Ayuda.
****/


IF @@TRANCOUNT > 0
set ANSI_NULLS ON 
set QUOTED_IDENTIFIER ON 

GO
BEGIN TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Clientes] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Clientes_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Clientes] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Clientes_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Clientes_Tombstone]( 
    [IDCliente] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Clientes_Tombstone] ADD CONSTRAINT [PKDEL_Clientes_Tombstone_IDCliente]
   PRIMARY KEY CLUSTERED
    ([IDCliente])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Clientes_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Clientes_DeletionTrigger] 
    ON [Clientes] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Clientes_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[IDCliente] = [Clientes_Tombstone].[IDCliente] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Clientes_Tombstone] 
    ([IDCliente], DeletionDate)
    SELECT [IDCliente], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Clientes_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Clientes_UpdateTrigger] 
    ON [dbo].[Clientes] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Clientes] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[IDCliente] = [Clientes].[IDCliente] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Clientes_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Clientes_InsertTrigger] 
    ON [dbo].[Clientes] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Clientes] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[IDCliente] = [Clientes].[IDCliente] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
