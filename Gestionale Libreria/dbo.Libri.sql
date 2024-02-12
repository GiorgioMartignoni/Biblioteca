CREATE TABLE [dbo].[Libri] (
    [id]         INT            IDENTITY (1, 1) NOT NULL ,
    [titolo]     NVARCHAR (MAX) NOT NULL ,
    [prestito]   BIT            NOT NULL ,
    [idGenere]   INT            NOT NULL ,
    [idScaffale] INT            NOT NULL ,
    CONSTRAINT [PK_Libri] PRIMARY KEY CLUSTERED ([id] ASC)
);

