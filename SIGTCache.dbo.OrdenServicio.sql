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
ALTER TABLE [dbo].[OrdenServicio] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_OrdenServicio_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[OrdenServicio] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_OrdenServicio_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenServicio_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[OrdenServicio_Tombstone]( 
    [IDOrden] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[OrdenServicio_Tombstone] ADD CONSTRAINT [PKDEL_OrdenServicio_Tombstone_IDOrden]
   PRIMARY KEY CLUSTERED
    ([IDOrden])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenServicio_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[OrdenServicio_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[OrdenServicio_DeletionTrigger] 
    ON [OrdenServicio] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[OrdenServicio_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[IDOrden] = [OrdenServicio_Tombstone].[IDOrden] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[OrdenServicio_Tombstone] 
    ([IDOrden], DeletionDate)
    SELECT [IDOrden], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenServicio_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[OrdenServicio_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[OrdenServicio_UpdateTrigger] 
    ON [dbo].[OrdenServicio] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[OrdenServicio] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[IDOrden] = [OrdenServicio].[IDOrden] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenServicio_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[OrdenServicio_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[OrdenServicio_InsertTrigger] 
    ON [dbo].[OrdenServicio] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[OrdenServicio] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[IDOrden] = [OrdenServicio].[IDOrden] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
