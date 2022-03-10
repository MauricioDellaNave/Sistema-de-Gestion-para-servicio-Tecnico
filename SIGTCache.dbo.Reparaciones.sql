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
ALTER TABLE [dbo].[Reparaciones] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Reparaciones_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Reparaciones] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Reparaciones_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reparaciones_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Reparaciones_Tombstone]( 
    [IDReparacion] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Reparaciones_Tombstone] ADD CONSTRAINT [PKDEL_Reparaciones_Tombstone_IDReparacion]
   PRIMARY KEY CLUSTERED
    ([IDReparacion])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reparaciones_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Reparaciones_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Reparaciones_DeletionTrigger] 
    ON [Reparaciones] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Reparaciones_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[IDReparacion] = [Reparaciones_Tombstone].[IDReparacion] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Reparaciones_Tombstone] 
    ([IDReparacion], DeletionDate)
    SELECT [IDReparacion], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reparaciones_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Reparaciones_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Reparaciones_UpdateTrigger] 
    ON [dbo].[Reparaciones] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Reparaciones] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[IDReparacion] = [Reparaciones].[IDReparacion] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reparaciones_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Reparaciones_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Reparaciones_InsertTrigger] 
    ON [dbo].[Reparaciones] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Reparaciones] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[IDReparacion] = [Reparaciones].[IDReparacion] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
