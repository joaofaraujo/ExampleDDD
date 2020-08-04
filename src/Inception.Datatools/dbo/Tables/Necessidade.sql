CREATE TABLE [dbo].[Necessidade] (
    [Id]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [IdInceptions] BIGINT        NOT NULL,
    [Descricao]    VARCHAR (300) NOT NULL,
    [Abreviacao]   VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Necessidade] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Necessidade_Inceptions] FOREIGN KEY ([IdInceptions]) REFERENCES [dbo].[Inceptions] ([Id])
);

