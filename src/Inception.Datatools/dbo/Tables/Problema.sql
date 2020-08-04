CREATE TABLE [dbo].[Problema] (
    [Id]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [IdInceptions] BIGINT        NOT NULL,
    [Descricao]    VARCHAR (300) NOT NULL,
    [Abreviacao]   VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Problema] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Problema_Inceptions] FOREIGN KEY ([IdInceptions]) REFERENCES [dbo].[Inceptions] ([Id])
);

