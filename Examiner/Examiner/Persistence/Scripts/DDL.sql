CREATE TABLE Category (
  id INTEGER PRIMARY KEY IDENTITY,
  name VARCHAR(200) NOT NULL,
  descript VARCHAR(200) NOT NULL
);

CREATE TABLE Exam (
  id INTEGER PRIMARY KEY IDENTITY,
  questionCount INTEGER NOT NULL,
  [open] char(1) NOT NULL,
  accessCode VARCHAR(10)
);

CREATE TABLE CategoryExam (
  id_category INTEGER NOT NULL REFERENCES Category,
  id_exam INTEGER NOT NULL REFERENCES Exam,
  PRIMARY KEY (id_category, id_exam)
);

CREATE TABLE Question (
  id INTEGER PRIMARY KEY IDENTITY,
  questionContent VARCHAR(200) NOT NULL,
  feedbackContent VARCHAR(200) NOT NULL,
  rightAlternative INTEGER NOT NULL,
  alternative1 VARCHAR(200) NOT NULL,
  alternative2 VARCHAR(200) NOT NULL,
  alternative3 VARCHAR(200) NOT NULL,
  alternative4 VARCHAR(200) NOT NULL,
  alternative5 VARCHAR(200) NOT NULL
);

CREATE TABLE CategoryQuestion (
  id_category INTEGER NOT NULL REFERENCES Category,
  id_question INTEGER NOT NULL REFERENCES Question,
  PRIMARY KEY (id_category, id_question)
);

CREATE TABLE Student (
  id INTEGER PRIMARY KEY IDENTITY,
  registration INTEGER NOT NULL,
  [password] VARCHAR(200) NOT NULL,
  name VARCHAR(200) NOT NULL,
  email VARCHAR(200) NOT NULL
);

CREATE TABLE StudentExam (
  id INTEGER PRIMARY KEY IDENTITY,
  id_student INTEGER NOT NULL REFERENCES Student,
  id_exam INTEGER NOT NULL REFERENCES Exam,
  UNIQUE ("id_student", "id_exam")
);

CREATE TABLE Answer (
  id_question INTEGER NOT NULL REFERENCES Question,
  id_studentexam_student INTEGER NOT NULL,
  id_studentexam_exam INTEGER NOT NULL,
  "alternative" INTEGER NOT NULL,
  PRIMARY KEY (id_question, id_studentexam_student, id_studentexam_exam),
  FOREIGN KEY (id_studentexam_student, id_studentexam_exam) REFERENCES StudentExam (id_student, id_exam)
);