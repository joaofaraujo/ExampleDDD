CREATE TABLE [dbo].[Inceptions] (
    [Id]              BIGINT        IDENTITY (1, 1) NOT NULL,
    [Nome]            VARCHAR (300) NOT NULL,
    [Identificador]   VARCHAR (30)  NOT NULL,
    [DataCriacao]     DATETIME2 (7) NOT NULL,
    [DataAtualizacao] DATETIME2 (7) NULL,
    CONSTRAINT [PK_Inceptions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

