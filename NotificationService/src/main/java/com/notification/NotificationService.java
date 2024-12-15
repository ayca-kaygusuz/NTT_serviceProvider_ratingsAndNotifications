package com.notification;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import org.springframework.stereotype.Service;

@Service
public class NotificationService {

    private static final Logger logger = LoggerFactory.getLogger(NotificationService.class);

    private final List<Notification> notifications = new ArrayList<>();

    public void addNotification(String message) {
        notifications.add(new Notification(message));
        logger.info("Added notification: {}", message); // Log the added notification
    }

    public List<Notification> getNotifications() {
        List<Notification> temp = new ArrayList<>(notifications);
        notifications.clear(); // Clear after fetching
        logger.info("Fetched {} notifications", temp.size()); // Log the number of notifications fetched
        return temp;
    }
}