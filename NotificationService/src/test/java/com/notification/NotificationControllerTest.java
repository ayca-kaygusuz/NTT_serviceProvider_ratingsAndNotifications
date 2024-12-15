package com.notification;

import java.util.Arrays;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import static org.mockito.Mockito.when;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.test.web.servlet.MockMvc;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.jsonPath;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;

@ExtendWith(MockitoExtension.class)
public class NotificationControllerTest {

    private MockMvc mockMvc;

    @Mock
    private NotificationService notificationService;

    @InjectMocks
    private NotificationController notificationController;

    @Test
    public void testAddNotification() throws Exception {
        mockMvc = MockMvcBuilders.standaloneSetup(notificationController).build();

        mockMvc.perform(post("/notifications")
                .param("message", "Test Notification"))
                .andExpect(status().isOk());
    }

    @Test
    public void testGetNotifications() throws Exception {
        mockMvc = MockMvcBuilders.standaloneSetup(notificationController).build();

        Notification notification1 = new Notification("First Notification");
        Notification notification2 = new Notification("Second Notification");

        when(notificationService.getNotifications()).thenReturn(Arrays.asList(notification1, notification2));

        mockMvc.perform(get("/notifications"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$[0].message").value("First Notification"))
                .andExpect(jsonPath("$[1].message").value("Second Notification"));
    }
}
