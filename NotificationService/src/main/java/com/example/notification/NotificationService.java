package com.example.notification;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Service;

@Service
public class NotificationService {
    private final List<Notification> notifications = new ArrayList<>();

    public void addNotification(String message) {
        notifications.add(new Notification(message));
    }

    public List<Notification> getNotifications() {
        List<Notification> temp = new ArrayList<>(notifications);
        notifications.clear(); // Clear after fetching
        return temp;
    }
}