package com.notification;

import static org.junit.jupiter.api.Assertions.*;

import java.util.List;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class NotificationServiceTest {
    private NotificationService notificationService;

    @BeforeEach
    public void setUp() {
        notificationService = new NotificationService();
    }

    @Test
    public void testAddNotification() {
        String message = "Test Notification";
        notificationService.addNotification(message);

        List<Notification> notifications = notificationService.getNotifications();
        assertEquals(1, notifications.size());
        assertEquals(message, notifications.get(0).getMessage());
    }

    @Test
    public void testGetNotifications_ClearsAfterFetching() {
        notificationService.addNotification("First Notification");
        notificationService.addNotification("Second Notification");

        List<Notification> notifications = notificationService.getNotifications();
        assertEquals(2, notifications.size());

        // Fetching again should return an empty list
        notifications = notificationService.getNotifications();
        assertTrue(notifications.isEmpty());
    }
}