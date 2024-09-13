-- Table Localisation
CREATE TABLE Localisation (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Street VARCHAR(255),
    number INT,
    postalCode VARCHAR(10)
);

-- Table Cegep
CREATE TABLE Cegep (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255),
    phoneNumber INT,
    localisation_id INT,
    FOREIGN KEY (localisation_id) REFERENCES Localisation(id)
);

-- Table Departement
CREATE TABLE Departement (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255),
    floor INT,
    cegep_id INT,
    FOREIGN KEY (cegep_id) REFERENCES Cegep(id)
);

-- Table Display
CREATE TABLE Display (
    id INT AUTO_INCREMENT PRIMARY KEY,
    departement_id INT,
    FOREIGN KEY (departement_id) REFERENCES Departement(id)
);

-- Table Content
CREATE TABLE Content (
    id INT AUTO_INCREMENT PRIMARY KEY,
    description TEXT,
    isVideo BOOLEAN,
    filePath VARCHAR(255),
    display_id INT,
    FOREIGN KEY (display_id) REFERENCES Display(id)
);

-- Table Local
CREATE TABLE Local (
    id INT AUTO_INCREMENT PRIMARY KEY,
    number INT,
    departement_id INT,
    FOREIGN KEY (departement_id) REFERENCES Departement(id)
);

-- Table Schedule
CREATE TABLE Schedule (
    id INT AUTO_INCREMENT PRIMARY KEY,
    date DATETIME,
    local_id INT,
    FOREIGN KEY (local_id) REFERENCES Local(id)
);

-- Table Teacher
CREATE TABLE Teacher (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255),
    mail VARCHAR(255)
);

-- Table Mark
CREATE TABLE Mark (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255)
);

-- Table Type
CREATE TABLE Type (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255)
);

-- Table Equipment
CREATE TABLE Equipment (
    id INT AUTO_INCREMENT PRIMARY KEY,
    description TEXT,
    mark_id INT,
    type_id INT,
    FOREIGN KEY (mark_id) REFERENCES Mark(id),
    FOREIGN KEY (type_id) REFERENCES Type(id)
);

-- Table Specificity
CREATE TABLE Specificity (
    id INT AUTO_INCREMENT PRIMARY KEY,
    description TEXT,
    equipment_id INT,
    FOREIGN KEY (equipment_id) REFERENCES Equipment(id)
);

-- Table Course
CREATE TABLE Course (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255),
    schedule_id INT,
    teacher_id INT,
    FOREIGN KEY (schedule_id) REFERENCES Schedule(id),
    FOREIGN KEY (teacher_id) REFERENCES Teacher(id)
);
