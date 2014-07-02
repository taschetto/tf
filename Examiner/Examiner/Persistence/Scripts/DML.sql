use [C:\USERS\GABRIEL\DOCUMENTS\GITHUB\TF\EXAMINER\EXAMINER\BIN\DEBUG\PERSISTENCE\DB\SUPERNOVA.MDF]
INSERT INTO Student VALUES(1,'123456', 'Gabriel Vargas' , 'gabriel.maciel@acad.pucrs.br');
INSERT INTO Student VALUES(2,'123456', 'Guilherme Taschetto' , 'guilherme.taschetto@acad.pucrs.br');
INSERT INTO Student VALUES(3,'123456', 'Giovanni Migon' , 'giovanni.ff@acad.pucrs.br');
INSERT INTO Student VALUES(4,'123456', 'Matheus Lima' , 'lima.m@acad.pucrs.br');
INSERT INTO Student VALUES(5,'123456', 'Darci Neto' , 'darci.net@acad.pucrs.br');
select * from Student
GO
INSERT INTO Category VALUES('Matematica','Perguntas sobre Matematica');
INSERT INTO Category VALUES('Ciência','Perguntas sobre Ciência');
INSERT INTO Category VALUES('Filosofia','Perguntas sobre Filosofia');
INSERT INTO Category VALUES('Física','Perguntas sobre Física');
INSERT INTO Category VALUES('História','Perguntas sobre História');
select * from Category
GO
INSERT INTO Exam VALUES(5,1,NULL);
INSERT INTO Exam VALUES(6,1,NULL);
INSERT INTO Exam VALUES(7,1,NULL);
INSERT INTO Exam VALUES(8,0,'DAwrqd');
INSERT INTO Exam VALUES(9,0,'DAewfw');
select * from Exam
go
INSERT INTO  CategoryExam VALUES(1,1);
INSERT INTO  CategoryExam VALUES(1,2);
INSERT INTO  CategoryExam VALUES(1,3);
INSERT INTO  CategoryExam VALUES(1,10);
INSERT INTO  CategoryExam VALUES(1,11);
INSERT INTO  CategoryExam VALUES(2,1);
INSERT INTO  CategoryExam VALUES(3,2);
INSERT INTO  CategoryExam VALUES(4,3);
INSERT INTO  CategoryExam VALUES(5,10);
INSERT INTO  CategoryExam VALUES(2,11);
select * from CategoryExam
go
INSERT INTO Question VALUES('Quanto é 2+2=?','é 4', 0,'4','5','7','10','-4');
INSERT INTO Question VALUES('Quem foi Chapolim Colorado ?','Um Grande Herói', 1,'Ninguem','O maior herói de todos os tempos','Da Vinci','Delorean','Roteador Cisco');
INSERT INTO Question VALUES('Quem foi Cândido Portinari ?',' foi um artista plástico brasileiro.',0,'Artista plástico brasileiro','Artista plástico Argentino','Da Vinci','Delorean','Roteador Cisco');
Select * from Question
GO
INSERT INTO StudentExam VALUES (1,1);
INSERT INTO StudentExam VALUES (1,2);
INSERT INTO StudentExam VALUES (1,3);
INSERT INTO StudentExam VALUES (1,10);
INSERT INTO StudentExam VALUES (2,1);
INSERT INTO StudentExam VALUES (2,2);
INSERT INTO StudentExam VALUES (2,3);
INSERT INTO StudentExam VALUES (2,11);
Select * from StudentExam
GO
INSERT INTO Answer VALUES (1,1,0);
INSERT INTO Answer VALUES (2,1,2);
INSERT INTO Answer VALUES (3,1,4);
INSERT INTO Answer VALUES (1,2,0);
select * from Answer
GO

INSERT INTO CategoryQuestion VALUES (1,1);
INSERT INTO CategoryQuestion VALUES (1,2);
INSERT INTO CategoryQuestion VALUES (1,4);
INSERT INTO CategoryQuestion VALUES (2,1);
INSERT INTO CategoryQuestion VALUES (2,2);
SELECT * FROM CategoryQuestion
GO






