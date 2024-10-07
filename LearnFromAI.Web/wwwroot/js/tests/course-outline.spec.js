import { getNavigationItems, getNavigationUrls } from '../course-outline.js';

describe('Course Outline Navigation', () => {
    // Mock course structure
    const mockCourse = {
        subjects: [
            {
                id: 1,
                headline: 'Subject 1',
                exercises: [
                    { id: 101, headline: 'Exercise 1.1' },
                    { id: 102, headline: 'Exercise 1.2' }
                ]
            },
            {
                id: 2,
                headline: 'Subject 2',
                exercises: [
                    { id: 201, headline: 'Exercise 2.1' }
                ]
            },
            {
                id: 3,
                headline: 'Subject 3',
                exercises: []
            }
        ]
    };

    let navigationItems;

    beforeEach(() => {
        navigationItems = getNavigationItems(mockCourse);
    });

    it('should create correct navigation items', () => {
        expect(navigationItems).toEqual([
            { type: 'subject', id: 1 },
            { type: 'exercise', id: 101 },
            { type: 'exercise', id: 102 },
            { type: 'subject', id: 2 },
            { type: 'exercise', id: 201 },
            { type: 'subject', id: 3 }
        ]);
    });

    describe('Navigation URLs', () => {
        it('should return correct URLs for first item', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, 0);
            expect(prevUrl).toBeNull();
            expect(nextUrl).toBe('/Exercise/101');
        });

        it('should return correct URLs for last item', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, navigationItems.length - 1);
            expect(prevUrl).toBe('/Exercise/201');
            expect(nextUrl).toBeNull();
        });

        it('should return correct URLs for middle item', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, 2);
            expect(prevUrl).toBe('/Exercise/101');
            expect(nextUrl).toBe('/Subject/2');
        });

        it('should handle navigation from subject to exercise', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, 0);
            expect(nextUrl).toBe('/Exercise/101');
        });

        it('should handle navigation from exercise to subject', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, 2);
            expect(nextUrl).toBe('/Subject/2');
        });

        it('should handle navigation between exercises in the same subject', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, 1);
            expect(prevUrl).toBe('/Subject/1');
            expect(nextUrl).toBe('/Exercise/102');
        });

        it('should handle navigation to a subject with no exercises', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, 4);
            expect(nextUrl).toBe('/Subject/3');
        });

        it('should handle navigation from a subject with no exercises', () => {
            const { prevUrl, nextUrl } = getNavigationUrls(navigationItems, 5);
            expect(prevUrl).toBe('/Exercise/201');
            expect(nextUrl).toBeNull();
        });
    });
});
