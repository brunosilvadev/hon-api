CREATE TABLE Reminder
(
    `ReminderId` int NOT NULL,
    `ReminderName` varchar(256) NOT NULL,
    `IsActive` boolean,
    `DateTime` datetime,
    PRIMARY KEY (ReminderId)
)

