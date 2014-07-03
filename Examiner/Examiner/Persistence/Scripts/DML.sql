DELETE FROM Answer;
DELETE FROM StudentExam;
DELETE FROM Student;
DELETE FROM CategoryQuestion;
DELETE FROM Question;
DELETE FROM CategoryExam;
DELETE FROM Exam;
DELETE FROM Category

DBCC CHECKIDENT (Answer, RESEED, 0);
DBCC CHECKIDENT (StudentExam, RESEED, 0);
DBCC CHECKIDENT (Student, RESEED, 0);
DBCC CHECKIDENT (Question, RESEED, 0);
DBCC CHECKIDENT (Exam, RESEED, 0);
DBCC CHECKIDENT (Category, RESEED, 0);

INSERT INTO Student VALUES(123456, 'abcde', 'Gabriel Vargas' , 'gabriel.maciel@acad.pucrs.br');
INSERT INTO Student VALUES(123456, 'abcde', 'Guilherme Taschetto' , 'guilherme.taschetto@acad.pucrs.br');
INSERT INTO Student VALUES(123456, 'abcde', 'Giovanni Migon' , 'giovanni.ff@acad.pucrs.br');
INSERT INTO Student VALUES(123456, 'abcde', 'Matheus Lima' , 'lima.m@acad.pucrs.br');
INSERT INTO Student VALUES(123456, 'abcde', 'Darci Neto' , 'darci.net@acad.pucrs.br');

INSERT INTO Category VALUES('Threads','Multitasking e sincronização.');
INSERT INTO Category VALUES('MVC','Padrão Movel View Controller.');
INSERT INTO Category VALUES('Design Patterns','Padrões de projetos estruturais e criacionais.');
INSERT INTO Category VALUES('Programação por Contratos','Programação por contratos e JML.');
INSERT INTO Category VALUES('Testes Unitários','Casos de teste e ferramentas de apoio');

INSERT INTO Exam VALUES(5, 1, '');
INSERT INTO Exam VALUES(8, 1, '');
INSERT INTO Exam VALUES(5, 0, 'DAwrqd');
INSERT INTO Exam VALUES(8, 0, 'DAewfw');

INSERT INTO CategoryExam VALUES(1, 1);
INSERT INTO CategoryExam VALUES(3, 1);
INSERT INTO CategoryExam VALUES(2, 2);
INSERT INTO CategoryExam VALUES(4, 2);
INSERT INTO CategoryExam VALUES(4, 3);
INSERT INTO CategoryExam VALUES(5, 3);
INSERT INTO CategoryExam VALUES(1, 4);
INSERT INTO CategoryExam VALUES(5, 4);

INSERT INTO Question VALUES('Questão 0','Feedback 0', 0, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 1','Feedback 1', 1, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 2','Feedback 2', 2, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 3','Feedback 3', 3, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 4','Feedback 4', 4, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 5','Feedback 5', 0, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 6','Feedback 6', 1, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 7','Feedback 7', 2, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 8','Feedback 8', 3, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 9','Feedback 9', 4, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 10','Feedback 10', 0, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 11','Feedback 11', 1, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 12','Feedback 12', 2, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 13','Feedback 13', 3, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 14','Feedback 14', 4, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 15','Feedback 15', 0, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 16','Feedback 16', 1, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 17','Feedback 17', 2, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 18','Feedback 18', 3, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');
INSERT INTO Question VALUES('Questão 19','Feedback 19', 4, 'Alternativa A', 'Alternativa B', 'Alternativa C', 'Alternativa D', 'Alternativa E');

INSERT INTO CategoryQuestion VALUES (1, 1);
INSERT INTO CategoryQuestion VALUES (1, 2);
INSERT INTO CategoryQuestion VALUES (1, 3);
INSERT INTO CategoryQuestion VALUES (1, 20);
INSERT INTO CategoryQuestion VALUES (2, 4);
INSERT INTO CategoryQuestion VALUES (2, 5);
INSERT INTO CategoryQuestion VALUES (2, 6);
INSERT INTO CategoryQuestion VALUES (2, 7);
INSERT INTO CategoryQuestion VALUES (3, 8);
INSERT INTO CategoryQuestion VALUES (3, 9);
INSERT INTO CategoryQuestion VALUES (3, 10);
INSERT INTO CategoryQuestion VALUES (3, 11);
INSERT INTO CategoryQuestion VALUES (4, 12);
INSERT INTO CategoryQuestion VALUES (4, 13);
INSERT INTO CategoryQuestion VALUES (4, 14);
INSERT INTO CategoryQuestion VALUES (4, 15);
INSERT INTO CategoryQuestion VALUES (5, 16);
INSERT INTO CategoryQuestion VALUES (5, 17);
INSERT INTO CategoryQuestion VALUES (5, 18);
INSERT INTO CategoryQuestion VALUES (5, 19);